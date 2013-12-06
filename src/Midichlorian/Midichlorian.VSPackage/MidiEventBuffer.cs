using System.Collections.Concurrent;
using Midi;

namespace YuriyGuts.Midichlorian.VSPackage
{
    internal class MidiEventBuffer
    {
        private ConcurrentQueue<NoteMessage> eventQueue;

        public MidiEventBuffer()
        {
            eventQueue = new ConcurrentQueue<NoteMessage>();
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
