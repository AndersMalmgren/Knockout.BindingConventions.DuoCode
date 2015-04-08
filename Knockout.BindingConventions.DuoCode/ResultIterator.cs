using System;
using System.Collections.Generic;
using DuoCode.Dom;

namespace Knockout.BindingConventions.DuoCode
{
    internal class ResultIterator
    {
        private readonly ResultContext context;
        private readonly IEnumerator<IResult> enumerator;

        public ResultIterator(IEnumerable<IResult> result, ResultContext context)
        {
            this.context = context;
            enumerator = result.GetEnumerator();
        }

        public void Execute()
        {
            MoveNext();
        }

        private void MoveNext()
        {
            if (enumerator.MoveNext())
                Global.window.setTimeout(new Action(HandleNext), 1);
        }

        private void HandleNext()
        {
            enumerator.Current.Completed += Current_Completed;
            enumerator.Current.Execute(context);
        }

        private void Current_Completed(object sender, ResultCompletionEventArgs e)
        {
            enumerator.Current.Completed -= Current_Completed;
            if (!e.WasCancelled)
            {
                MoveNext();
            }
        }
    }
}