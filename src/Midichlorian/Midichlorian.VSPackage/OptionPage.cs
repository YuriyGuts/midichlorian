using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace YuriyGuts.Midichlorian.VSPackage
{
    /// <summary>
    /// Handles the interaction with the VS Options page.
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid(PackageGuids.PackageOptionsGuidString)]
    public class OptionPage : DialogPage
    {
        private OptionPageControl optionPageControl;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override IWin32Window Window
        {
            get
            {
                if (optionPageControl == null)
                {
                    optionPageControl = new OptionPageControl();
                }
                return optionPageControl;
            }
        }

        protected override void OnActivate(CancelEventArgs e)
        {
            base.OnActivate(e);
            optionPageControl.ApplySettingsToUI(SettingsPersistenceManager.LoadSettings());
        }

        public override void SaveSettingsToStorage()
        {
            base.SaveSettingsToStorage();
            var newSettings = optionPageControl.GetSettingsFromUI();
            SettingsPersistenceManager.SaveSettings(newSettings);
        }
    }
}
