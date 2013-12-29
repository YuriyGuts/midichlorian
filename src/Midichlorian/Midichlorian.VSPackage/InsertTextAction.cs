using Microsoft.VisualStudio.Text.Editor;

namespace YuriyGuts.Midichlorian.VSPackage
{
    /// <summary>
    /// A MIDI-triggered action that causes the VS text editor to insert a piece of text at the caret position.
    /// </summary>
    public class InsertTextAction : IdeAutomatableAction
    {
        public override string Name { get { return "Insert Text"; } }

        public override int DisplayOrder
        {
            get { return 0; }
        }

        public override void Execute(object state)
        {
            var textView = state as IWpfTextView;
            if (textView == null)
            {
                return;
            }

            var textToInsert = string.Empty;
            if (Parameters.ContainsKey("Text"))
            {
                textToInsert = Parameters["Text"];
            }

            textView.VisualElement.Dispatcher.Invoke(() =>
            {
                if (textView.Caret.InVirtualSpace)
                {
                    var spacerString = string.Empty.PadRight(textView.Caret.Position.VirtualSpaces);
                    textView.TextBuffer.Insert(textView.Caret.Position.BufferPosition, spacerString);
                    textView.Caret.MoveTo(textView.Caret.Position.BufferPosition);
                }
                textView.TextBuffer.Insert(textView.Caret.Position.BufferPosition, textToInsert);
            });
        }
    }
}
