using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace YuriyGuts.Midichlorian.VSPackage
{
    /// <summary>
    /// Handles the tasks related to saving and loading settings from files.
    /// </summary>
    internal static class SettingsPersistenceManager
    {
        private const string Xml_RootElement = "Midichlorian";
        private const string Xml_MidiInputDeviceNameElement = "MidiInputDeviceName";
        private const string Xml_MidiMappingsElement = "MidiMappings";
        private const string Xml_MappingElement = "Mapping";
        private const string Xml_TriggerInputSequenceAttr = "inputSequence";
        private const string Xml_ActionAttr = "action";
        private const string Xml_ParamAttrPrefix = "param";
        private const string Xml_Base64Prefix = "base64:";

        public static SettingsModel LoadSettings()
        {
            string fileContents = File.ReadAllText(GetSettingsFileName());
            var settingsDocument = XDocument.Parse(fileContents);

            var settings = new SettingsModel();
            settings.MidiInputDeviceName = settingsDocument.Root.Element(Xml_MidiInputDeviceNameElement).Value;
            settings.MidiMappingProfile = LoadMappingsFromXElement(settingsDocument.Root.Element(Xml_MidiMappingsElement));

            return settings;
        }

        public static void SaveSettings(SettingsModel settings)
        {
            var settingsDocument = CreateBlankXDocument();

            settingsDocument.Root.SetElementValue(Xml_MidiInputDeviceNameElement, settings.MidiInputDeviceName);
            settingsDocument.Root.Element(Xml_MidiMappingsElement).Add(ConvertMappingsToXElements(settings.MidiMappingProfile));

            settingsDocument.Save(GetSettingsFileName());
        }

        public static MidiMappingProfile LoadMappingsFromFile(string fileName)
        {
            var xmlDocument = XDocument.Parse(File.ReadAllText(fileName));
            return LoadMappingsFromXElement(xmlDocument.Root.Element(Xml_MidiMappingsElement));
        }

        public static void SaveMappingsToFile(MidiMappingProfile mappingProfile, string fileName)
        {
            XDocument profileDocument = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                    Xml_RootElement,
                    new XElement(Xml_MidiMappingsElement, ConvertMappingsToXElements(mappingProfile))
                )
            );
            profileDocument.Save(fileName);
        }

        public static string DecodeActionParameter(string paramValue)
        {
            string result = paramValue;
            if (paramValue.StartsWith(Xml_Base64Prefix))
            {
                result = Encoding.UTF8.GetString(Convert.FromBase64String(paramValue.Substring(Xml_Base64Prefix.Length)));
            }
            return result;
        }

        public static string EncodeActionParameter(string paramValue)
        {
            string result = paramValue;
            if (StringNeedsToBeEscaped(paramValue))
            {
                result = Xml_Base64Prefix + Convert.ToBase64String(Encoding.UTF8.GetBytes(paramValue));
            }
            return result;
        }

        public static bool StringNeedsToBeEscaped(string value)
        {
            try
            {
                XmlConvert.VerifyXmlChars(value);
            }
            catch (XmlException)
            {
                return false;
            }

            var chars = value.ToCharArray();
            return chars.Any(c => c < 32 || c == '\"' || c == '\'' || c == '>' || c == '<' || c == '&');
        }

        private static string GetSettingsFileName()
        {
            const string fileName = "Settings.xml";

            string appDataPath = Environment.GetFolderPath
            (
                Environment.SpecialFolder.ApplicationData, 
                Environment.SpecialFolderOption.Create
            );
            string packageVersionString = string.Format("VSPackage-v{0}", Assembly.GetExecutingAssembly().GetName().Version);

            string settingsFolderPath = Path.Combine(appDataPath, Xml_RootElement, packageVersionString);
            if (!Directory.Exists(settingsFolderPath))
            {
                Directory.CreateDirectory(settingsFolderPath);
            }

            string fullFileName = Path.Combine(settingsFolderPath, fileName);
            if (!File.Exists(fullFileName))
            {
                CreateBlankSettingsFile(fullFileName);
            }

            return fullFileName;
        }

        private static void CreateBlankSettingsFile(string fileName)
        {
            var settingsDocument = CreateBlankXDocument();
            settingsDocument.Save(fileName);
        }

        private static XDocument CreateBlankXDocument()
        {
            XDocument settingsDocument = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                    Xml_RootElement,
                    new XElement(Xml_MidiInputDeviceNameElement, string.Empty),
                    new XElement(Xml_MidiMappingsElement)
                )
            );
            return settingsDocument;
        }

        private static MidiMappingProfile LoadMappingsFromXElement(XElement element)
        {
            var mappingProfile = new MidiMappingProfile();
            foreach (var mappingElement in element.Elements())
            {
                var actionType = Type.GetType(typeof(MidichlorianPackage).Namespace
                    + "."
                    + mappingElement.Attribute(Xml_ActionAttr).Value);

                MidiMappingRecord mappingRecord = new MidiMappingRecord
                {
                    Trigger = MidiInputTrigger.Parse(mappingElement.Attribute(Xml_TriggerInputSequenceAttr).Value),
                    Action = (IdeAutomatableAction)Activator.CreateInstance(actionType),
                };

                var paramAttributes = mappingElement
                    .Attributes()
                    .Where(attr => attr.Name.LocalName.StartsWith(Xml_ParamAttrPrefix));

                foreach (var param in paramAttributes)
                {
                    string paramUnprefixedName = param.Name.LocalName.Substring(Xml_ParamAttrPrefix.Length);
                    mappingRecord.Action.Parameters[paramUnprefixedName] = DecodeActionParameter(param.Value);
                }

                mappingProfile.Mappings.Add(mappingRecord);
            }
            return mappingProfile;
        }

        private static IEnumerable<XElement> ConvertMappingsToXElements(MidiMappingProfile mappingProfile)
        {
            return mappingProfile.Mappings.Select(mapping =>
                new XElement
                (
                    Xml_MappingElement,
                    new XAttribute(Xml_TriggerInputSequenceAttr, mapping.Trigger.ToString()),
                    new XAttribute(Xml_ActionAttr, mapping.Action.GetType().Name),
                    mapping.Action.Parameters
                        .Select(kvp => new XAttribute(Xml_ParamAttrPrefix + kvp.Key, EncodeActionParameter(kvp.Value)))
                        .ToList()
                ));
        }
    }
}
