using System.Linq;
using Microsoft.VisualStudio.Text.Editor;
using Midi;

namespace YuriyGuts.Midichlorian.VSPackage
{
    class TextViewAgent
    {
        private IWpfTextView textView;
        private SettingsModel settings;
        private MidiMappingMatcher mappingMatcher;
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

        private void textView_GotAggregateFocus(object sender, System.EventArgs e)
        {
            midiDevice.Open();
            midiDevice.StartReceiving(null);
        }

        private void textView_LostAggregateFocus(object sender, System.EventArgs e)
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

            var singleMatch = mappingMatcher.FindSingleNoteMatches(msg.Pitch);
            if (singleMatch != null && singleMatch.Action.GetType() == typeof(InsertTextAction))
            {
                singleMatch.Action.Execute(textView);
            }
        }
    }
}
