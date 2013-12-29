using System.Collections.Concurrent;
using Midi;

namespace YuriyGuts.Midichlorian.VSPackage
{
    /// <summary>
    /// Represents a set of MIDI events that are recorded within a continuous time period.
    /// </summary>
    internal class MidiEventBuffer
    {
        private ConcurrentQueue<NoteMessage> eventQueue;

        public MidiEventBuffer()
        {
            eventQueue = new ConcurrentQueue<NoteMessage>();
        }

        public bool IsEmpty
        {
            get { return eventQueue.IsEmpty; }
        }

        public void Add(NoteMessage note)
        {
            eventQueue.Enqueue(note);
        }

        public NoteMessage[] Flush()
        {
            var flushedItems = eventQueue.ToArray();
            eventQueue = new ConcurrentQueue<NoteMessage>();
            return flushedItems;
        }
    }
}
