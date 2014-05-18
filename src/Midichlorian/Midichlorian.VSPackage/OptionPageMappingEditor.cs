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

                RefreshActionSelection();
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
                .Cast<IdeAutomatableAction>()
                .OrderBy(act => act.DisplayOrder)
                .ToArray();

            cmbAction.DataSource = actions;
            
            if (actions.Length > 0)
            {
                cmbAction.SelectedItem = actions[0];
                action = actions[0];
            }
        }

        private void RefreshActionSelection()
        {
            cmbAction.SelectedItem = cmbAction.Items.Cast<IdeAutomatableAction>().FirstOrDefault(item => item.GetType() == action.GetType());
        }

        private void RefreshMidiInputText()
        {
            txtInputTrigger.Text = inputTrigger != null ? inputTrigger.ToString() : string.Empty;
        }

        private void RefreshParameterText()
        {
            if (action != null)
            {
                txtActionParams.Text = action.Parameters.Count > 0
                    ? SettingsPersistenceManager.EncodeActionParameter(action.Parameters.First().Value)
                    : string.Empty;
            }
        }

        private void SaveActionParameters(string parameters)
        {
            action.LoadParametersFromString(parameters);
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
            string initialValue = txtActionParams.Text;
            using (var extendedParamForm = new ActionExtendedParameterEditForm())
            {
                var formDisplayPoint = PointToScreen(new Point(txtActionParams.Left, txtActionParams.Top + txtActionParams.Height));
                extendedParamForm.Left = formDisplayPoint.X;
                extendedParamForm.Top = formDisplayPoint.Y;

                extendedParamForm.LoadDataIntoUI(initialValue);
                var result = extendedParamForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    return SettingsPersistenceManager.EncodeActionParameter(extendedParamForm.GetDataFromUI());
                }
            }
            return initialValue;
        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedAction = (IdeAutomatableAction)cmbAction.SelectedValue;
            if (selectedAction != null && (action == null || selectedAction.GetType() != action.GetType()))
            {
                action = selectedAction;
            }
            RefreshParameterText();
        }
    }
}
