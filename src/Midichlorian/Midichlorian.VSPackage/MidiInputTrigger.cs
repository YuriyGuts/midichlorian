using System;
using System.Globalization;
using System.Linq;
using Midi;

namespace YuriyGuts.Midichlorian.VSPackage
{
    public class MidiInputTrigger
    {
        private static readonly char[] separatorChars = { ',' };
        private static readonly string separatorString = separatorChars[0].ToString(CultureInfo.InvariantCulture);

        public Pitch[] Pitches { get; private set; }

        public bool IsSingleNote
        {
            get { return Pitches.Length == 1; }
        }

        public bool IsChord
        {
            get { return Pitches.Length > 1; }
        }

        public MidiInputTrigger(Pitch pitch)
        {
            Pitches = new[] { pitch };
        }

        public MidiInputTrigger(Pitch[] pitches)
        {
            Pitches = pitches;
        }

        public static MidiInputTrigger Parse(string sequence)
        {
            var notes = sequence.Split(separatorChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(PitchFromString)
                .ToArray();
            return new MidiInputTrigger(notes);
        }

        public override string ToString()
        {
            return string.Join(separatorString, Pitches.Select(PitchToString));
        }

        public static Pitch PitchFromString(string pitchString)
        {
            var parsePos = 0;
            var note = Note.ParseNote(pitchString, ref parsePos);
            var octave = int.Parse(pitchString.Substring(parsePos));
            return note.PitchInOctave(octave);
        }

        public static string PitchToString(Pitch pitch)
        {
            return string.Format("{0}{1}", pitch.NotePreferringSharps(), pitch.Octave());
        }
    }
}
