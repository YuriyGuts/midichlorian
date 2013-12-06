using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.Text.Editor;
using Midi;

namespace YuriyGuts.Midichlorian.VSPackage
{
    internal class TextViewAgent
    {
        private static readonly TimeSpan chordWaitTime = TimeSpan.FromMilliseconds(100);

        private IWpfTextView textView;
        private SettingsModel settings;
        private MidiMappingMatcher mappingMatcher;
        private MidiEventBuffer eventBuffer;
        private InputDevice midiDevice;

        public TextViewAgent(IWpfTextView view)
        {
            textView = view;
            LoadSettings();
            SetUpMidiListener();
        }

        private void LoadSettings()
        {
            settings = SettingsPersistenceManager.LoadSettings();
            mappingMatcher = new MidiMappingMatcher(settings.MidiMappingProfile);
        }

        private void SetUpMidiListener()
        {
            // TODO: Handle the case when the device is changed via Options page.
            if (midiDevice != null)
            {
                return;
            }

            midiDevice = InputDevice.InstalledDevices.FirstOrDefault(dev => dev.Name == settings.MidiInputDeviceName);
            if (midiDevice == null)
            {
                return;
            }
            midiDevice.NoteOn += MidiInputDevice_NoteOn;

            textView.GotAggregateFocus += textView_GotAggregateFocus;
            textView.LostAggregateFocus += textView_LostAggregateFocus;
        }

        private void textView_GotAggregateFocus(object sender, EventArgs e)
        {
            midiDevice.Open();
            midiDevice.StartReceiving(null);
        }

        private void textView_LostAggregateFocus(object sender, EventArgs e)
        {
            midiDevice.StopReceiving();
            midiDevice.Close();
        }

        private void MidiInputDevice_NoteOn(NoteOnMessage msg)
        {
            // Somehow, when I release a key on my Axiom 61, a NoteOn message is received with Velocity = 0.
            // Not sure if it's specific to Axiom, MidiDotNet library, or my environment setup.
            if (msg.Velocity == 0)
            {
                return;
            }

            // If we're already waiting for a chord to complete, then store the note for further processing and move on.
            if (eventBuffer != null)
            {
                eventBuffer.Add(msg);
                return;
            }

            var chordMatches = mappingMatcher.FindChordMatches(msg.Pitch);
            if (chordMatches.Length > 0)
            {
                // If the note belongs to a chord, we should hold on for a short time
                // and allow other notes from this chord to be received, then execute actions.
                Interlocked.CompareExchange(ref eventBuffer, new MidiEventBuffer(), null);
                eventBuffer.Add(msg);

                // While this thread stores the incoming notes to the buffer,
                // a background thread will watch the time and process the buffer afterwards.
                new Thread(WaitAndFinalizeChord).Start();
                return;
            }

            var singleNoteMatches = mappingMatcher.FindSingleNoteMatches(msg.Pitch);
            ExecuteMappedActions(singleNoteMatches);
        }

        private void ExecuteMappedActions(IEnumerable<MidiMappingRecord> matchedMappings)
        {
            foreach (var mapping in matchedMappings)
            {
                if (mapping.Action is InsertTextAction)
                {
                    mapping.Action.Execute(textView);
                }
                // Put other action handlers here.
            }
        }

        private void WaitAndFinalizeChord()
        {
            // Allow to store other chord notes in the buffer.
            Thread.Sleep(chordWaitTime);

            // Process collected events.
            var bufferedEvents = eventBuffer.Flush();
            var matchedMappings = mappingMatcher.FindBufferMatches(bufferedEvents);
            ExecuteMappedActions(matchedMappings);

            // Reset the buffer to return to normal mode.
            Interlocked.CompareExchange(ref eventBuffer, null, eventBuffer);
        }
    }
}
