using System.Collections.Generic;

namespace YuriyGuts.Midichlorian.VSPackage
{
    /// <summary>
    /// Contains a set of records that map MIDI events to automatable IDE actions.
    /// </summary>
    public class MidiMappingProfile
    {
        public List<MidiMappingRecord> Mappings = new List<MidiMappingRecord>();
    }
}
