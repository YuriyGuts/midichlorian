using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Midi;

namespace YuriyGuts.Midichlorian.VSPackage
{
    partial class OptionPageControl : UserControl
    {
        private static readonly TimeSpan chordWaitTime = TimeSpan.FromMilliseconds(100);

        private SettingsModel settings;
        private OptionPageMappingEditor midiInputLearnTargetControl;
        private MidiEventBuffer eventBuffer;

        public OptionPageControl()
        {
            InitializeComponent();
        }

        private InputDevice SelectedMidiDevice
        {
            get { return (InputDevice)cmbMidiInputDevice.SelectedItem; }
        }

        private InputDevice ReceivingMidiDevice { get; set; }

        public void ApplySettingsToUI(SettingsModel newSettings)
        {
            BindData(newSettings);
        }

        public SettingsModel GetSettingsFromUI()
        {
            var newMappingProfile = new MidiMappingProfile();
            ForEachMappingControl(control => newMappingProfile.Mappings.Add(control.GetMappingRecord()));
            
            // Controls are stacked, and the bottom-most control is on top of the stack. So we should reverse the order.
            newMappingProfile.Mappings.Reverse();

            return new SettingsModel
            {
                MidiInputDeviceName = SelectedMidiDevice != null ? SelectedMidiDevice.Name : string.Empty,
                MidiMappingProfile = newMappingProfile,
            };
        }

        private void ToggleMidiDeviceTestMode(bool enableTesting)
        {
            if (enableTesting)
            {
                lblMidiTestStatus.Text = "Press any MIDI key...";
                lblMidiTestStatus.ForeColor = Color.CornflowerBlue;
                lblMidiTestStatus.Visible = true;

                try
                {
                    StartReceivingMidi();
                }
                catch (Exception ex)
                {
                    lblMidiTestStatus.ForeColor = Color.Red;
                    lblMidiTestStatus.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                StopReceivingMidi();
                lblMidiTestStatus.Visible = false;
            }
        }

        private void StartReceivingMidi()
        {
            if (!SelectedMidiDevice.IsReceiving)
            {
                SelectedMidiDevice.Open();
                SelectedMidiDevice.NoteOn += ReceivingMidiDevice_NoteOn;
                SelectedMidiDevice.StartReceiving(null);
                ReceivingMidiDevice = SelectedMidiDevice;
            }
        }

        private void StopReceivingMidi()
        {
            if (ReceivingMidiDevice != null)
            {
                ReceivingMidiDevice.NoteOn -= ReceivingMidiDevice_NoteOn;
                ReceivingMidiDevice.StopReceiving();
                ReceivingMidiDevice.Close();
                ReceivingMidiDevice = null;
            }
        }

        private void BindData(SettingsModel newSettings)
        {
            cmbMidiInputDevice.DataSource = InputDevice.InstalledDevices;
            settings = newSettings;

            foreach (var midiDevice in InputDevice.InstalledDevices.Where(dev => dev.Name == settings.MidiInputDeviceName))
            {
                cmbMidiInputDevice.SelectedItem = midiDevice;
                break;
            }
            LoadMappings();
        }

        private void LoadMappings()
        {
            ForEachMappingControl(RemoveMappingEditorControl);
            foreach (var mapping in settings.MidiMappingProfile.Mappings)
            {
                AddMappingEditorControl(mapping);
            }
        }

        private void AddMappingEditorControl(MidiMappingRecord record)
        {
            var newEditor = new OptionPageMappingEditor();
            newEditor.Dock = DockStyle.Top;
            newEditor.MidiInputLearnRequested += mappingEditor_MidiInputLearnRequested;
            newEditor.DeleteRequested += mappingEditor_DeleteRequested;
            newEditor.SetMappingRecord(record);
            pnlMappingListItems.Controls.Add(newEditor);
            pnlMappingListItems.Controls.SetChildIndex(newEditor, 0);
        }

        private void RemoveMappingEditorControl(OptionPageMappingEditor control)
        {
            pnlMappingListItems.Controls.Remove(control);
            control.Dispose();
        }

        private void ForEachMappingControl(Action<OptionPageMappingEditor> action)
        {
            // Copying items aggressively to support Remove operation.
            var applicableControls = pnlMappingListItems.Controls
                .OfType<OptionPageMappingEditor>()
                .ToList();

            foreach (var control in applicableControls)
            {
                action(control);
            }
        }

        private void ReceivingMidiDevice_NoteOn(NoteOnMessage msg)
        {
            // Somehow, when I release a key on my Axiom 61, a NoteOn message is received with Velocity = 0.
            // Not sure if it's specific to Axiom, MidiDotNet library, or my environment setup.
            if (msg.Velocity == 0)
            {
                return;
            }

            if (midiInputLearnTargetControl != null)
            {
                if (eventBuffer.IsEmpty)
                {
                    // Let's try to capture a chord.
                    // While this thread stores the incoming notes to the buffer,
                    // a background thread will watch the time and process the buffer afterwards.
                    new Thread(WaitAndFinalizeChord).Start();
                }

                eventBuffer.Add(msg);
                return;
            }

            if (chkTestMidiInputDevice.Checked)
            {
                Invoke(new Action(() =>
                {
                    lblMidiTestStatus.ForeColor = Color.Green;
                    lblMidiTestStatus.Text = string.Format
                    (
                        "Pitch: {0}   Velocity: {1}",
                        PitchConverter.PitchToString(msg.Pitch),
                        msg.Velocity
                    );
                }));
            }
        }

        private void chkTestMidiInputDevice_CheckedChanged(object sender, EventArgs e)
        {
            ToggleMidiDeviceTestMode(chkTestMidiInputDevice.Checked);
        }

        private void cmbMidiInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool midiDevicesExist = cmbMidiInputDevice.Items.Count > 0;
            chkTestMidiInputDevice.Checked = false;
            chkTestMidiInputDevice.Enabled = midiDevicesExist;
            grpMappings.Enabled = midiDevicesExist;
        }

        private void tbtnAddMapping_Click(object sender, EventArgs e)
        {
            AddMappingEditorControl(null);
        }

        private void tbtnImportFile_Click(object sender, EventArgs e)
        {
            var openDialogResult = openProfileDialog.ShowDialog(this);
            if (openDialogResult == DialogResult.OK)
            {
                var mappingProfile = SettingsPersistenceManager.LoadMappingsFromFile(openProfileDialog.FileName);
                settings.MidiMappingProfile = mappingProfile;
                LoadMappings();
            }
        }

        private void tbtnExportFile_Click(object sender, EventArgs e)
        {
            var saveDialogResult = saveProfileDialog.ShowDialog(this);
            if (saveDialogResult == DialogResult.OK)
            {
                var mappingProfile = GetSettingsFromUI().MidiMappingProfile;
                SettingsPersistenceManager.SaveMappingsToFile(mappingProfile, saveProfileDialog.FileName);
            }
        }

        private void mappingEditor_MidiInputLearnRequested(object sender, EventArgs e)
        {
            chkTestMidiInputDevice.Checked = false;

            if (midiInputLearnTargetControl != null && midiInputLearnTargetControl != sender)
            {
                midiInputLearnTargetControl.TeachMidiInput(null);
            }

            midiInputLearnTargetControl = (OptionPageMappingEditor)sender;

            // Hold on for a short time and allow other notes from this chord to be received.
            Interlocked.CompareExchange(ref eventBuffer, new MidiEventBuffer(), null);

            StartReceivingMidi();
        }

        private void mappingEditor_DeleteRequested(object sender, EventArgs e)
        {
            RemoveMappingEditorControl((OptionPageMappingEditor)sender);
        }

        private void WaitAndFinalizeChord()
        {
            // Allow to store other chord notes in the buffer.
            Thread.Sleep(chordWaitTime);
            StopReceivingMidi();

            // Process collected events.
            var bufferedEvents = eventBuffer.Flush();
            var inputTrigger = new MidiInputTrigger(bufferedEvents.Select(e => e.Pitch).OrderBy(p => p).ToArray());

            // Reset the buffer to return to normal mode.
            Interlocked.CompareExchange(ref eventBuffer, null, eventBuffer);

            var oldTargetControl = midiInputLearnTargetControl;
            midiInputLearnTargetControl = null;

            Invoke(new Action(() => oldTargetControl.TeachMidiInput(inputTrigger)));
        }
    }
}
