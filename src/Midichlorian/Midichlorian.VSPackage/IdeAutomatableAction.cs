using System.Collections.Generic;

namespace YuriyGuts.Midichlorian.VSPackage
{
    public abstract class IdeAutomatableAction
    {
        protected IdeAutomatableAction()
        {
            Parameters = new Dictionary<string, string>();
        }

        public abstract string Name { get; }

        public Dictionary<string, string> Parameters { get; set; }

        public abstract void Execute(object state);
    }
}
