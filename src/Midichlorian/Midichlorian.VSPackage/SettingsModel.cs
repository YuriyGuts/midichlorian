namespace YuriyGuts.Midichlorian.VSPackage
{
    /// <summary>
    /// Represents the user-configurable settings applicable to this VS package.
    /// </summary>
    public class SettingsModel
    {
        public string MidiInputDeviceName { get; set; }

        public MidiMappingProfile MidiMappingProfile { get; set; }
    }
}
