using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace YuriyGuts.Midichlorian.VSPackage
{
    internal static class SettingsPersistenceManager
    {
        public static SettingsModel LoadSettings()
        {
            string fileContents = File.ReadAllText(GetSettingsFileName());
            var settingsDocument = XDocument.Parse(fileContents);

            var settings = new SettingsModel();
            settings.MidiInputDeviceName = settingsDocument.Root.Element("MidiInputDeviceName").Value;
            settings.MidiMappingProfile = LoadMappingsFromXElement(settingsDocument.Root.Element("MidiMappings"));

            return settings;
        }

        public static void SaveSettings(SettingsModel settings)
        {
            var settingsDocument = CreateBlankXDocument();

            settingsDocument.Root.SetElementValue("MidiInputDeviceName", settings.MidiInputDeviceName);
            settingsDocument.Root.Element("MidiMappings").Add(ConvertMappingsToXElements(settings.MidiMappingProfile));

            settingsDocument.Save(GetSettingsFileName());
        }

        public static MidiMappingProfile LoadMappingsFromFile(string fileName)
        {
            var xmlDocument = XDocument.Parse(File.ReadAllText(fileName));
            return LoadMappingsFromXElement(xmlDocument.Root.Element("MidiMappings"));
        }

        public static void SaveMappingsToFile(MidiMappingProfile mappingProfile, string fileName)
        {
            XDocument profileDocument = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement
                (
                    "Midichlorian",
                    new XElement("MidiMappings", ConvertMappingsToXElements(mappingProfile))
                )
            );
            profileDocument.Save(fileName);
        }

        private static string GetSettingsFileName()
        {
            const string fileName = "Settings.xml";

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
            string packageVersionString = string.Format("VSPackage-v{0}", Assembly.GetExecutingAssembly().GetName().Version);
            
            string settingsFolderPath = Path.Combine(appDataPath, "Midichlorian", packageVersionString);
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
                    "Midichlorian",
                    new XElement("MidiInputDeviceName", string.Empty),
                    new XElement("MidiMappings")
                )
            );
            return settingsDocument;
        }

        private static MidiMappingProfile LoadMappingsFromXElement(XElement element)
        {
            var mappingProfile = new MidiMappingProfile();
            foreach (var mappingElement in element.Elements())
            {
                var actionType = Type.GetType(typeof(MidichlorianPackage).Namespace + "." + mappingElement.Attribute("action").Value);

                MidiMappingRecord mappingRecord = new MidiMappingRecord
                {
                    Trigger = MidiInputTrigger.Parse(mappingElement.Attribute("inputSequence").Value),
                    Action = (IdeAutomatableAction)Activator.CreateInstance(actionType),
                };

                foreach (var param in mappingElement.Attributes().Where(attr => attr.Name.LocalName.StartsWith("param")))
                {
                    mappingRecord.Action.Parameters[param.Name.LocalName.Substring("param".Length)] = param.Value;
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
                    "Mapping",
                    new XAttribute("inputSequence", mapping.Trigger.ToString()),
                    new XAttribute("action", mapping.Action.GetType().Name),
                    mapping.Action.Parameters.Select(kvp => new XAttribute("param" + kvp.Key, kvp.Value)).ToList()
                ));
        }
    }
}
