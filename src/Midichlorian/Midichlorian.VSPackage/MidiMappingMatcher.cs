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

        public MidiMappingRecord[] FindSingleNoteMatches(Pitch pitch)
        {
            return mappingProfile.Mappings
                .Where(mapping => mapping.Trigger.IsSingleNote && mapping.Trigger.Pitches[0] == pitch)
                .ToArray();
        }

        public MidiMappingRecord[] FindChordMatches(Pitch pitch)
        {
            return mappingProfile.Mappings
                .Where(mapping => mapping.Trigger.IsChord && mapping.Trigger.Pitches.Any(p => p == pitch))
                .ToArray();
        }

        public MidiMappingRecord[] FindBufferMatches(NoteMessage[] bufferedEvents)
        {
            var results = new List<MidiMappingRecord>();
            var events = (NoteMessage[])bufferedEvents.Clone();

            // Process chords first.
            // This is O(scary), but seems quick enough in practice. (c) StackOverflow #184618
            foreach (var mapping in mappingProfile.Mappings.Where(m => m.Trigger.IsChord))
            {
                bool isChordComplete = mapping.Trigger.Pitches.All(p => events.Any(e => e != null && e.Pitch == p));
                if (isChordComplete)
                {
                    // Exclude matched notes from further processing.
                    for (int i = 0; i < events.Length; i++)
                    {
                        var pitch = events[i].Pitch;
                        if (mapping.Trigger.Pitches.Any(p => p == pitch))
                        {
                            events[i] = null;
                        }
                    }
                    results.Add(mapping);
                }
            }

            // Process remaining single notes.
            foreach (var e in events.Where(e => e != null))
            {
                results.AddRange(FindSingleNoteMatches(e.Pitch));
            }

            return results.ToArray();
        }
    }
}
