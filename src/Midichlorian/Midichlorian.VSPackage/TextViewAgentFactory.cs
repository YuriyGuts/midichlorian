using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace YuriyGuts.Midichlorian.VSPackage
{
    /// <summary>
    /// Notifies the VS host that we need to listen to text editor creation events
    /// and instantiates a TextViewAgent when an IWpfTextView has been created.
    /// </summary>
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
            // Weird, right? But this is the way it's supposed to be according to the VS SDK template.
            new TextViewAgent(textView);
        }
    }
}
