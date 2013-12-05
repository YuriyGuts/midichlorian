using System.Collections.Generic;
using Microsoft.VisualStudio.Text.Editor;

namespace YuriyGuts.Midichlorian.VSPackage
{
    public class InsertTextAction : IdeAutomatableAction
    {
        public override string Name { get { return "Insert Text"; } }

        public Dictionary<string, string> Options { get; set; }

        public override void Execute(object state)
        {
            var textView = state as IWpfTextView;
            if (textView == null)
            {
                return;
            }

            var textToInsert = string.Empty;
            if (Options.ContainsKey("Text"))
            {
                textToInsert = Options["Text"];
            }

            textView.VisualElement.Dispatcher.Invoke(() =>
            {
                using (var editOperation = textView.TextBuffer.CreateEdit())
                {
                    editOperation.Insert(textView.Caret.Position.BufferPosition, textToInsert);
                    editOperation.Apply();
                }
            });
        }
    }
}
