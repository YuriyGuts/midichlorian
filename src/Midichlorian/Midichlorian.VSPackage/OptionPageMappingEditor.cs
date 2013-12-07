using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace YuriyGuts.Midichlorian.VSPackage
{
    public partial class OptionPageMappingEditor : UserControl
    {
        private readonly Color inputNormalColor = Color.FromArgb(248, 248, 248);
        private readonly Color inputLearnColor = Color.FromArgb(224, 255, 224);

        private MidiInputTrigger inputTrigger;
        private IdeAutomatableAction action;

        public event EventHandler MidiInputLearnRequested;
        public event EventHandler DeleteRequested;

        public OptionPageMappingEditor()
        {
            InitializeComponent();
        }

        public void SetMappingRecord(MidiMappingRecord record)
        {
            LoadActions();

            if (record != null)
            {
                inputTrigger = record.Trigger;
                action = record.Action;

                RefreshMidiInputText();
                RefreshParameterText();
            }
        }

        public MidiMappingRecord GetMappingRecord()
        {
            SaveActionParameters(txtActionParams.Text);

            return new MidiMappingRecord
            {
                Trigger = inputTrigger,
                Action = action,
            };
        }

        public void TeachMidiInput(MidiInputTrigger trigger)
        {
            inputTrigger = trigger;
            txtInputTrigger.BackColor = inputNormalColor;
            RefreshMidiInputText();
        }

        private void LoadActions()
        {
            var actions = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => typeof(IdeAutomatableAction).IsAssignableFrom(type) && !type.IsAbstract)
                .Select(Activator.CreateInstance)
                .ToArray();

            cmbAction.DataSource = actions;
            
            if (actions.Length > 0)
            {
                cmbAction.SelectedItem = actions[0];
                action = (IdeAutomatableAction)actions[0];
            }
        }

        private void RefreshMidiInputText()
        {
            txtInputTrigger.Text = inputTrigger != null ? inputTrigger.ToString() : string.Empty;
        }

        private void RefreshParameterText()
        {
            if (action != null)
            {
                txtActionParams.Text = action.Parameters.First().Value;
            }
        }

        private void SaveActionParameters(string parameters)
        {
            if (action is InsertTextAction)
            {
                action.Parameters["Text"] = parameters;
            }
        }

        protected virtual void OnMidiInputLearnRequested()
        {
            EventHandler handler = MidiInputLearnRequested;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnDeleteRequested()
        {
            EventHandler handler = DeleteRequested;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void btnLearnInputFromMidi_Click(object sender, EventArgs e)
        {
            StartLearnMidiInput();
        }

        private void StartLearnMidiInput()
        {
            txtInputTrigger.BackColor = inputLearnColor;
            txtInputTrigger.Text = "Press MIDI keys";
            OnMidiInputLearnRequested();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteRequested();
        }

        private void btnActionExtendedParams_Click(object sender, EventArgs e)
        {
            var extendedParams = GetExtendedParameterInput();
            SaveActionParameters(extendedParams);
            RefreshParameterText();
        }

        private string GetExtendedParameterInput()
        {
            return "base64:DQo=";
        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedAction = (IdeAutomatableAction)cmbAction.SelectedValue;
            if (selectedAction != null)
            {
                action = selectedAction;
            }
            RefreshParameterText();
        }
    }
}
