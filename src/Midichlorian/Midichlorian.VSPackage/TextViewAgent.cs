using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text.Editor;

namespace YuriyGuts.Midichlorian.VSPackage
{
    class TextViewAgent
    {
        private IWpfTextView textView;

        public TextViewAgent(IWpfTextView view)
        {
            textView = view;
            LoadSettings();
            SetUpMidiListener();
        }

        private void LoadSettings()
        {
        }

        private void SetUpMidiListener()
        {
        }
    }
}
