using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace Knockout.BindingConventions.DuoCode
{
    public static class Binding
    {
        public static void Init()
        {
            Js.referenceAs<Action<Func<Func<IEnumerable<IResult>>, HTMLElement, BindingContext, Action>>>(@"(function(factory) {
    var orgApply = ko.bindingConventions.conventionBinders.button.apply;
    ko.bindingConventions.conventionBinders.button.apply = function(name, element, bindings, unwrapped, type, dataFn, bindingContext) {
        var handler = factory(unwrapped, element, bindingContext);

        dataFn = function() { return handler };
        orgApply(name, element, bindings, handler, type, dataFn, bindingContext);

    };
})")
                (InitButtonHandler);


        }

        public static Action InitButtonHandler(Func<IEnumerable<IResult>> handler, HTMLElement element, BindingContext bindingContext)
        {
            return () =>
            {
                var results = handler();
                if (results != null)
                {
                    var context = new ResultContext(element, bindingContext);
                    var iterator = new ResultIterator(results, context);
                    iterator.Execute();
                }

            };
        }
    }

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
            enumerator.Current.Execute(context);
            MoveNext();
        }
    }

    public interface IResult
    {
        void Execute(ResultContext context);
    }

    [Js(Extern = true)]
    public class BindingContext
    {
        [Js(Name = "$data")]
        public object Data;

        [Js(Name = "$parent")]
        public object Parent;

        [Js(Name = "$parents")]
        public object[] Parents;

        [Js(Name = "$parentContext")]
        public object ParentContext;

        [Js(Name = "$rawData")]
        public object RawData;

        [Js(Name = "$root")]
        public object Root;
    }

    public class ResultContext
    {
        public ResultContext(HTMLElement element, BindingContext bindingContext)
        {
            Element = element;
            BindingContext = bindingContext;
        }

        public HTMLElement Element { get; private set; }
        public BindingContext BindingContext { get; private set; }

    }


    public class ViewLocator
    {
        [Js(Name = "getView")]
        public string GetView(object viewModel)
        {
            const string modelEndsWith = "Model";
            var className = viewModel.GetType().FullName;

            var template = className;

            if (className != null && className.EndsWith(modelEndsWith))
            {
                template = className.Substring(0, className.Length - modelEndsWith.Length);
                if (!template.EndsWith("View"))
                {
                    template = template + "View";
                }
            }

            return template;
        }
    }
}
