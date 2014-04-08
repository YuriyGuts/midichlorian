using System;
using Midi;
using NUnit.Framework;
using YuriyGuts.Midichlorian.VSPackage;

namespace Midichlorian.VSPackage.Tests
{
    [TestFixture]
    public class PitchConverter_Tests
    {
        [TestCase(Pitch.A1, Result = "A1")]
        [TestCase(Pitch.B1, Result = "B1")]
        [TestCase(Pitch.C1, Result = "C1")]
        [TestCase(Pitch.D1, Result = "D1")]
        [TestCase(Pitch.E1, Result = "E1")]
        [TestCase(Pitch.F1, Result = "F1")]
        [TestCase(Pitch.G1, Result = "G1")]
        public string PitchToString_UnalteredNotesPassed_DoesNotAddSharpsOrFlats_Test(Pitch pitch)
        {
            return PitchConverter.PitchToString(pitch);
        }

        [TestCase(Pitch.ASharp0, Result = "A#0")]
        [TestCase(Pitch.CSharp0, Result = "C#0")]
        [TestCase(Pitch.DSharp0, Result = "D#0")]
        [TestCase(Pitch.FSharp0, Result = "F#0")]
        [TestCase(Pitch.GSharp0, Result = "G#0")]
        public string PitchToString_AlteredNotesPassed_AddsAlterationSymbols_Test(Pitch pitch)
        {
            return PitchConverter.PitchToString(pitch);
        }

        [TestCase(Pitch.CNeg1, Result = "C-1")]
        [TestCase(Pitch.CSharpNeg1, Result = "C#-1")]
        public string PitchToString_NegativeOctavePassed_NegativeOctaveInOutput_Test(Pitch pitch)
        {
            return PitchConverter.PitchToString(pitch);
        }

        [TestCase("A1", Result = Pitch.A1)]
        [TestCase("B2", Result = Pitch.B2)]
        [TestCase("C3", Result = Pitch.C3)]
        [TestCase("D4", Result = Pitch.D4)]
        [TestCase("E5", Result = Pitch.E5)]
        [TestCase("F6", Result = Pitch.F6)]
        [TestCase("G7", Result = Pitch.G7)]
        public Pitch PitchFromString_CorrectUnalteredNotesPassed_ParsesCorrectly_Test(string pitchString)
        {
            return PitchConverter.PitchFromString(pitchString);
        }

        [TestCase("H1")]
        public void PitchFromString_IncorrectBNotationPassed_ThrowsException_Test(string pitchString)
        {
            Assert.Throws<ArgumentException>(() => PitchConverter.PitchFromString(pitchString));
        }

        [TestCase("E#1", Result = Pitch.F1)]
        [TestCase("B#1", Result = Pitch.C2)]
        public Pitch PitchFromString_IrregularSingleSharpsPassed_ParsesCorrectly_Test(string pitchString)
        {
            return PitchConverter.PitchFromString(pitchString);
        }

        [TestCase("Bb1")]
        [TestCase("Db1")]
        [TestCase("Eb1")]
        public void PitchFromString_FlatsPassed_ThrowsException_Test(string pitchString)
        {
            Assert.Throws<ArgumentException>(() => PitchConverter.PitchFromString(pitchString));
        }

        [TestCase("Bbb1")]
        [TestCase("D##1")]
        [TestCase("E###1")]
        [TestCase("F####1")]
        public void PitchFromString_DoubleAccidentalsPassed_ThrowsException_Test(string pitchString)
        {
            Assert.Throws<ArgumentException>(() => PitchConverter.PitchFromString(pitchString));
        }
    }
}
