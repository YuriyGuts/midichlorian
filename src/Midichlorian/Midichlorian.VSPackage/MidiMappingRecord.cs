namespace YuriyGuts.Midichlorian.VSPackage
{
    /// <summary>
    /// Represents a single entry of a MIDI mapping profile.
    /// Maps one or more MIDI events to an action that should be executed by the VS host.
    /// </summary>
    public class MidiMappingRecord
    {
        public MidiInputTrigger Trigger { get; set; }

        public IdeAutomatableAction Action { get; set; }
    }
}
