using System;
using Midi;
using NUnit.Framework;
using YuriyGuts.Midichlorian.VSPackage;

namespace Midichlorian.VSPackage.Tests
{
    [TestFixture]
    internal class MidiInputTrigger_Tests
    {
        [Test]
        public void Constructor_SingleNotePassed_ReportsSingleNote_Test()
        {
            // Act
            var sut = new MidiInputTrigger(Pitch.A0);

            // Assert
            Assert.IsTrue(sut.IsSingleNote);
            Assert.IsFalse(sut.IsChord);
        }

        [Test]
        public void Constructor_SingleNoteArrayPassed_ReportsSingleNote_Test()
        {
            // Arrange
            var pitchArray = new[] { Pitch.A0 };

            // Act
            var sut = new MidiInputTrigger(pitchArray);

            // Assert
            Assert.IsTrue(sut.IsSingleNote);
            Assert.IsFalse(sut.IsChord);
        }

        [Test]
        public void Constructur_MultipleNotesPassed_ReportsChord_Test()
        {
            // Arrange
            var pitchArray = new[] { Pitch.A0, Pitch.A1 };

            // Act
            var sut = new MidiInputTrigger(pitchArray);

            // Assert
            Assert.IsFalse(sut.IsSingleNote);
            Assert.IsTrue(sut.IsChord);
        }

        [Test]
        public void Parse_SingleNotePassed_ParsesAndStoresTheNote_Test()
        {
            // Act
            var sut = MidiInputTrigger.Parse("C#0");

            // Assert
            Assert.IsTrue(sut.IsSingleNote);
            Assert.AreEqual(Pitch.CSharp0, sut.Pitches[0]);
        }

        [Test]
        public void Parse_MultipleNotesPassedCommaSeparatedNoSpaces_ParsesAndStoresTheNotes_Test()
        {
            // Act
            var sut = MidiInputTrigger.Parse("C#1,D2,D#3");

            // Assert
            Assert.AreEqual(3, sut.Pitches.Length);
            Assert.AreEqual(Pitch.CSharp1, sut.Pitches[0]);
            Assert.AreEqual(Pitch.D2, sut.Pitches[1]);
            Assert.AreEqual(Pitch.DSharp3, sut.Pitches[2]);
        }

        [Test]
        public void Parse_MultipleNotesPassedCommaSeparatedWithSpaces_ParsesAndStoresTheNotes_Test()
        {
            // Act
            var sut = MidiInputTrigger.Parse("C#1, D2,   D#3,D4,  ");

            // Assert
            Assert.AreEqual(4, sut.Pitches.Length);
            Assert.AreEqual(Pitch.CSharp1, sut.Pitches[0]);
            Assert.AreEqual(Pitch.D2, sut.Pitches[1]);
            Assert.AreEqual(Pitch.DSharp3, sut.Pitches[2]);
            Assert.AreEqual(Pitch.D4, sut.Pitches[3]);
        }

        [Test]
        public void Parse_MultipleNotesPassedInvalidSeparator_ThrowsException_Test()
        {
            // Act
            TestDelegate action = (() => MidiInputTrigger.Parse("C#1;D2;D#3"));

            // Assert
            Assert.Throws<FormatException>(action);
        }

        [Test]
        public void ToString_SingleNote_ReturnsStringWithoutSeparators_Test()
        {
            // Arrange
            var sut = new MidiInputTrigger(Pitch.A0);

            // Act
            var triggerString = sut.ToString();

            // Assert
            Assert.AreEqual("A0", triggerString);
        }

        [Test]
        public void ToString_MultipleNotes_ReturnsStringWithSeparators_Test()
        {
            // Arrange
            var sut = new MidiInputTrigger(new [] { Pitch.C0, Pitch.CSharp0 });

            // Act
            var triggerString = sut.ToString();

            // Assert
            Assert.AreEqual("C0,C#0", triggerString);
        }
    }
}
