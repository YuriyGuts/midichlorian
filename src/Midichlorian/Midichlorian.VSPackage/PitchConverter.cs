using System;
using Midi;

namespace YuriyGuts.Midichlorian.VSPackage
{
    /// <summary>
    /// Provides utilities for serializing/deserializing Pitch objects from other formats.
    /// </summary>
    internal class PitchConverter
    {
        public static string PitchToString(Pitch pitch)
        {
            return string.Format("{0}{1}", pitch.NotePreferringSharps(), pitch.Octave());
        }

        public static Pitch PitchFromString(string pitchString)
        {
            var parsePos = 0;
            var note = Note.ParseNote(pitchString, ref parsePos);
            var octave = int.Parse(pitchString.Substring(parsePos));

            // Support B#.
            if (note.Letter == 'B' && note.Accidental == 1)
            {
                note = new Note('C');
                octave++;
            }

            // Do not allow flats and double accidentals (YAGNI).
            if (note.Accidental < 0 || note.Accidental > 1)
            {
                throw new ArgumentException("Flats and double accidentals are note supported.");
            }

            return note.PitchInOctave(octave);
        }
    }
}
