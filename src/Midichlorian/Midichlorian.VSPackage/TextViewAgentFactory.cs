using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace YuriyGuts.Midichlorian.VSPackage
{
    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    internal sealed class TextViewAgentFactory : IWpfTextViewCreationListener
    {
        [Export(typeof(AdornmentLayerDefinition))]
        [Name("TextViewAgent")]
        [Order(After = PredefinedAdornmentLayers.Caret)]
        public AdornmentLayerDefinition editorAdornmentLayer = null;

        /// <summary>
        /// Instantiates a TextViewAgent when a WpfTextView is created.
        /// </summary>
        /// <param name="textView">The <see cref="IWpfTextView"/> upon which the adornment should be placed</param>
        public void TextViewCreated(IWpfTextView textView)
        {
            new TextViewAgent(textView);
        }
    }
}
