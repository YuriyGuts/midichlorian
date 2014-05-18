using FakeItEasy;
using Midi;
using NUnit.Framework;
using YuriyGuts.Midichlorian.VSPackage;

namespace Midichlorian.VSPackage.Tests
{
    [TestFixture]
    internal class MidiEventBuffer_Tests
    {
        [Test]
        public void DefaultConstructor_ReportsEmpty_Test()
        {
            // Act
            var sut = new MidiEventBuffer();

            // Assert
            Assert.IsTrue(sut.IsEmpty);
        }

        [Test]
        public void Add_EmptyQueue_AddOneItem_ReportsNotEmpty_Test()
        {
            // Arrange
            var sut = new MidiEventBuffer();
            var message = A.Fake<NoteMessage>();

            // Act
            sut.Add(message);

            // Assert
            Assert.IsFalse(sut.IsEmpty);
        }

        [Test]
        public void Flush_EmptyQueue_ReturnsEmptyArray_Test()
        {
            // Arrange
            var sut = new MidiEventBuffer();

            // Act
            var flushedItems = sut.Flush();

            // Assert
            Assert.IsEmpty(flushedItems);
        }

        [Test]
        public void Flush_QueueWithOneItem_ReturnsArrayWithSameItem_Test()
        {
            // Arrange
            var sut = new MidiEventBuffer();
            var message = A.Fake<NoteMessage>();
            sut.Add(message);

            // Act
            var flushedItems = sut.Flush();

            // Assert
            Assert.AreEqual(1, flushedItems.Length);
            Assert.AreEqual(message, flushedItems[0]);
        }

        [Test]
        public void Flush_EmptyQueue_ReportsEmpty_Test()
        {
            // Arrange
            var sut = new MidiEventBuffer();

            // Act
            var flushedItems = sut.Flush();

            // Assert
            Assert.IsTrue(sut.IsEmpty);
        }

        [Test]
        public void Flush_NonEmptyQueue_ReportsEmpty_Test()
        {
            // Arrange
            var sut = new MidiEventBuffer();
            var message = A.Fake<NoteMessage>();
            sut.Add(message);

            // Act
            var flushedItems = sut.Flush();

            // Assert
            Assert.IsTrue(sut.IsEmpty);
        }
    }
}
