using System;
using System.Windows.Forms;

namespace YuriyGuts.Midichlorian.VSPackage
{
    public partial class ActionExtendedParameterEditForm : Form
    {
        public ActionExtendedParameterEditForm()
        {
            InitializeComponent();
        }

        public void LoadDataIntoUI(string paramString)
        {
            txtExtendedParams.Text = paramString;
        }

        public string GetDataFromUI()
        {
            return txtExtendedParams.Text;
        }

        private void txtExtendedParams_TextChanged(object sender, EventArgs e)
        {
            lblEscapeWarning.Visible = SettingsPersistenceManager.StringNeedsToBeEscaped(txtExtendedParams.Text);
        }
    }
}
