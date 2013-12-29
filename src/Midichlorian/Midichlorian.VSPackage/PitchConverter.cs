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
            return note.PitchInOctave(octave);
        }
    }
}
