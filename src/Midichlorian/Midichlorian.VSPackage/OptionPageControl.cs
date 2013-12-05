using System;
using System.Drawing;
using System.Windows.Forms;
using Midi;

namespace YuriyGuts.Midichlorian.VSPackage
{
    partial class OptionPageControl : UserControl
    {
        private SettingsModel settings;

        public OptionPageControl()
        {
            InitializeComponent();
        }

        private InputDevice SelectedMidiDevice
        {
            get { return (InputDevice)cmbMidiInputDevice.SelectedItem; }
        }

        private InputDevice ReceivingMidiDevice { get; set; }

        public void ApplySettingsToUI(SettingsModel settings)
        {
            BindData(settings);
        }

        // TODO: Refactor this.
        public SettingsModel GetSettingsFromUI()
        {
            return new SettingsModel
            {
                MidiInputDeviceName = SelectedMidiDevice != null ? SelectedMidiDevice.Name : string.Empty,
                MidiMappingProfile = settings.MidiMappingProfile,
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
                    SelectedMidiDevice.Open();
                    SelectedMidiDevice.NoteOn += ReceivingMidiDevice_NoteOn;
                    SelectedMidiDevice.StartReceiving(null);
                    ReceivingMidiDevice = SelectedMidiDevice;
                }
                catch (Exception ex)
                {
                    lblMidiTestStatus.ForeColor = Color.Red;
                    lblMidiTestStatus.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                if (ReceivingMidiDevice != null)
                {
                    ReceivingMidiDevice.NoteOn -= ReceivingMidiDevice_NoteOn;
                    ReceivingMidiDevice.StopReceiving();
                    ReceivingMidiDevice.Close();
                    ReceivingMidiDevice = null;
                }
                lblMidiTestStatus.Visible = false;
            }
        }

        private void BindData(SettingsModel newSettings)
        {
            cmbMidiInputDevice.DataSource = InputDevice.InstalledDevices;
            settings = newSettings;
            LoadMappings();
        }

        private void LoadMappings()
        {

        }

        private void ReceivingMidiDevice_NoteOn(NoteOnMessage msg)
        {
            // Somehow, when I release a key on my Axiom 61, a NoteOn message is received with Velocity = 0.
            // Not sure if it's specific to Axiom, MidiDotNet library, or my environment setup.
            if (msg.Velocity == 0)
            {
                return;
            }

            // MIDI receiver runs in a separate thread.
            Invoke(new Action(() =>
            {
                lblMidiTestStatus.ForeColor = Color.Green;
                lblMidiTestStatus.Text = string.Format("Pitch: {0}   Velocity: {1}", msg.Pitch, msg.Velocity);
            }));
        }

        private void chkTestMidiInputDevice_CheckedChanged(object sender, EventArgs e)
        {
            ToggleMidiDeviceTestMode(chkTestMidiInputDevice.Checked);
        }

        private void cmbMidiInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkTestMidiInputDevice.Checked = false;
            chkTestMidiInputDevice.Enabled = cmbMidiInputDevice.Items.Count > 0;
        }
    }
}
