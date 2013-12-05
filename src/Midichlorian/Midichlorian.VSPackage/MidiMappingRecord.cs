using System;

namespace YuriyGuts.Midichlorian.VSPackage
{
    public class MidiMappingRecord
    {
        public MidiInputTrigger Trigger { get; set; }

        public IdeAutomatableAction Action { get; set; }
    }
}
