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
            Js.referenceAs<Action<object>>(@"(function(viewLocator) {
            ko.bindingConventions.viewLocator.instance = viewLocator;
                                                      })")
                (new ViewLocator());

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
}
