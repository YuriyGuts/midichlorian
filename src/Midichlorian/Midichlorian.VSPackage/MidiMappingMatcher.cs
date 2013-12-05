using System.Collections.Generic;
using System.Linq;
using Midi;

namespace YuriyGuts.Midichlorian.VSPackage
{
    internal class MidiMappingMatcher
    {
        private readonly MidiMappingProfile mappingProfile;

        public MidiMappingMatcher(MidiMappingProfile mappingProfile)
        {
            this.mappingProfile = mappingProfile;
        }

        public MidiMappingRecord FindSingleNoteMatches(Pitch pitch)
        {
            var matchingMappings = mappingProfile.Mappings
                .Where(mapping => mapping.Trigger.IsSingleNote
                    && mapping.Trigger.Pitches[0] == pitch)
                .ToArray();

            if (matchingMappings.Length == 1)
            {
                return matchingMappings[0];
            }
            return null;
        }

        public IEnumerable<MidiMappingRecord> FindChordMatches(Pitch pitch)
        {
            var matchingChords = mappingProfile.Mappings
                .Where(mapping => mapping.Trigger.IsChord
                    && mapping.Trigger.Pitches.Any(p => p == pitch))
                .ToArray();
            return matchingChords;
        }
    }
}
