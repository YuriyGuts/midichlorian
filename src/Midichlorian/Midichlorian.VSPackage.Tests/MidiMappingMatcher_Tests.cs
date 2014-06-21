using System;
using System.Collections.Generic;
using System.Linq;
using Midi;
using NUnit.Framework;
using YuriyGuts.Midichlorian.VSPackage;

namespace Midichlorian.VSPackage.Tests
{
    [TestFixture]
    internal class MidiMappingMatcher_Tests
    {
        private readonly MidiMappingProfile emptyMappingProfile = new MidiMappingProfile();

        [Test]
        public void FindSingleNoteMatches_EmptyMappingProfile_DoesNotMatchAnything_Test()
        {
            // Arrange
            var matcher = new MidiMappingMatcher(emptyMappingProfile);

            // Assert
            foreach (var pitch in Enum.GetValues(typeof(Pitch)).Cast<Pitch>())
            {
                Assert.AreEqual(0, matcher.FindSingleNoteMatches(pitch).Length);
            }
        }

        [Test]
        public void FindChordMatchesContainingNote_EmptyMappingProfile_DoesNotMatchAnything_Test()
        {
            // Arrange
            var matcher = new MidiMappingMatcher(emptyMappingProfile);

            // Assert
            foreach (var pitch in Enum.GetValues(typeof(Pitch)).Cast<Pitch>())
            {
                Assert.AreEqual(0, matcher.FindChordMatchesContainingNote(pitch).Length);
            }
        }

        [Test]
        public void FindMatchesInBuffer_EmptyMappingProfile_DoesNotMatchAnything_Test()
        {
            // Arrange
            var matcher = new MidiMappingMatcher(emptyMappingProfile);
            var buffer = new [] { Pitch.C1, Pitch.E2, Pitch.G1, Pitch.E1, Pitch.C2 };

            // Act
            var matchesFound = matcher.FindMatchesInBuffer(buffer);

            // Assert
            Assert.AreEqual(0, matchesFound.Length);
        }

        [Test]
        public void FindSingleNoteMatches_OctavesDoNotMatch_DoesNotMatchAnything_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.C1) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.A2) },
                }
            };

            var matcher = new MidiMappingMatcher(profile);

            // Assert
            Assert.AreEqual(0, matcher.FindSingleNoteMatches(Pitch.C0).Length);
            Assert.AreEqual(0, matcher.FindSingleNoteMatches(Pitch.C2).Length);
            Assert.AreEqual(0, matcher.FindSingleNoteMatches(Pitch.A0).Length);
            Assert.AreEqual(0, matcher.FindSingleNoteMatches(Pitch.A1).Length);
            Assert.AreEqual(0, matcher.FindSingleNoteMatches(Pitch.A3).Length);
        }

        [Test]
        public void FindSingleNoteMatches_NoSingleNotesInProfile_DoesNotMatchAnything_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.C1, Pitch.E1, Pitch.G1 }) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.A1, Pitch.C2, Pitch.E2 }) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.G1, Pitch.B1, Pitch.D2, Pitch.FSharp2 }) },
                }
            };

            var matcher = new MidiMappingMatcher(profile);

            // Assert
            Assert.AreEqual(0, matcher.FindSingleNoteMatches(Pitch.C1).Length);
            Assert.AreEqual(0, matcher.FindSingleNoteMatches(Pitch.E1).Length);
            Assert.AreEqual(0, matcher.FindSingleNoteMatches(Pitch.G1).Length);
            Assert.AreEqual(0, matcher.FindSingleNoteMatches(Pitch.FSharp2).Length);
        }

        [Test]
        public void FindSingleNoteMatches_SingleMatchingRecord_OneMatchFound_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.C1) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.A2) },
                }
            };

            var matcher = new MidiMappingMatcher(profile);

            // Act
            var matchesFound = matcher.FindSingleNoteMatches(Pitch.A2);

            // Assert
            Assert.AreEqual(1, matchesFound.Length);
            Assert.AreEqual(Pitch.A2, matchesFound[0].Trigger.Pitches[0]);
        }

        [Test]
        public void FindSingleNoteMatches_DuplicateRecords_AllMatchesFound_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.C1) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.A2) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.C1) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.C1) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.C1, Pitch.E1, Pitch.G1 })},
                }
            };

            var matcher = new MidiMappingMatcher(profile);

            // Act
            var matchesFound = matcher.FindSingleNoteMatches(Pitch.C1);

            // Assert
            Assert.AreEqual(3, matchesFound.Length);
            foreach (var match in matchesFound)
            {
                Assert.AreEqual(Pitch.C1, match.Trigger.Pitches[0]);
            }
        }

        [Test]
        public void FindChordMatchesContainingNote_NoChordsInProfile_DoesNotMatchAnything_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.C1) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.A2) },
                }
            };

            var matcher = new MidiMappingMatcher(profile);

            // Act
            var matchesFound = matcher.FindChordMatchesContainingNote(Pitch.C1);

            // Assert
            Assert.AreEqual(0, matchesFound.Length);
        }

        [Test]
        public void FindChordMatchesContainingNote_MultipleMatchingRecords_AllMatchesFound_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.C1, Pitch.E1, Pitch.G1 }) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.A0, Pitch.C1, Pitch.E1 }) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.G1, Pitch.B1, Pitch.C2, Pitch.FSharp2 }) },
                }
            };

            var matcher = new MidiMappingMatcher(profile);

            // Act
            var matchesFound = matcher.FindChordMatchesContainingNote(Pitch.C1);

            // Assert
            Assert.AreEqual(2, matchesFound.Length);
        }

        [Test]
        public void FindMatchesInBuffer_ChordNotesInInvertedOrder_MatchesChordSuccessfully_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.C1, Pitch.E1, Pitch.G1 }) },
                }
            };

            var matcher = new MidiMappingMatcher(profile);
            var straightOrder = new[] { Pitch.C1, Pitch.E1, Pitch.G1 };
            var inversion1 = new[] { Pitch.E1, Pitch.G1, Pitch.C1 };
            var inversion2 = new[] { Pitch.G1, Pitch.C1, Pitch.E1 };
            var inversion3 = new[] { Pitch.C1, Pitch.G1, Pitch.E1 };

            // Assert
            Assert.AreEqual(1, matcher.FindMatchesInBuffer(straightOrder).Length);
            Assert.AreEqual(1, matcher.FindMatchesInBuffer(inversion1).Length);
            Assert.AreEqual(1, matcher.FindMatchesInBuffer(inversion2).Length);
            Assert.AreEqual(1, matcher.FindMatchesInBuffer(inversion3).Length);
        }

        [Test]
        public void FindMatchesInBuffer_ChordNotesAndSingleNotesCaptured_MatchesAll_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.A1) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.D1) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.C1, Pitch.E1, Pitch.G1 }) },
                }
            };

            var matcher = new MidiMappingMatcher(profile);
            var buffer = new[] { Pitch.C1, Pitch.E1, Pitch.G1, Pitch.D1, Pitch.A1 };

            // Act
            var matchesFound = matcher.FindMatchesInBuffer(buffer);

            // Assert
            Assert.AreEqual(3, matchesFound.Length);
        }

        [Test]
        public void FindMatchesInBuffer_SingleNotesMixedWithUnmappedNotes_MatchesSingleNotesSuccessfully_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.A1) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.D1) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.E1) },
                }
            };

            var matcher = new MidiMappingMatcher(profile);
            var buffer = new[] { Pitch.C1, Pitch.E1, Pitch.D1, Pitch.G1, Pitch.D1, Pitch.A1, Pitch.F1 };

            // Act
            var matchesFound = matcher.FindMatchesInBuffer(buffer);

            // Assert
            Assert.AreEqual(4, matchesFound.Length);
        }

        [Test]
        public void FindMatchesInBuffer_ChordNotesMixedWithUnmappedNotes_MatchesChordSuccessfully_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.C1, Pitch.E1, Pitch.G1 }) },
                }
            };

            var matcher = new MidiMappingMatcher(profile);
            var buffer = new [] { Pitch.C1, Pitch.E2, Pitch.G1, Pitch.E1, Pitch.C2 };

            // Act
            var matchesFound = matcher.FindMatchesInBuffer(buffer);

            // Assert
            Assert.AreEqual(1, matchesFound.Length);
        }

        [Test]
        public void FindMatchesInBuffer_SingleNoteMappingOverlapsWithChordMapping_ChordTakesPriority_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(Pitch.E1) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.C1, Pitch.E1, Pitch.G1 }) },
                }
            };

            var matcher = new MidiMappingMatcher(profile);
            var buffer = new [] { Pitch.C1, Pitch.E2, Pitch.G1, Pitch.E1, Pitch.C2 };

            // Act
            var matchesFound = matcher.FindMatchesInBuffer(buffer);

            // Assert
            Assert.AreEqual(1, matchesFound.Length);
            Assert.IsTrue(matchesFound[0].Trigger.IsChord);
        }

        [Test]
        public void FindMatchesInBuffer_TwoOverlappingChordsCaptured_MatchesTheBiggerOne_Test()
        {
            // Arrange
            var profile = new MidiMappingProfile
            {
                Mappings = new List<MidiMappingRecord>
                {
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.C1, Pitch.G1 }) },
                    new MidiMappingRecord { Trigger = new MidiInputTrigger(new[] { Pitch.C1, Pitch.E1, Pitch.G1 }) },
                }
            };

            var matcher = new MidiMappingMatcher(profile);
            var buffer = new[] { Pitch.C1, Pitch.E1, Pitch.G1 };

            // Act
            var matchesFound = matcher.FindMatchesInBuffer(buffer);

            // Assert
            Assert.AreEqual(1, matchesFound.Length);
            Assert.AreEqual(3, matchesFound[0].Trigger.Pitches.Length);
        }
    }
}
