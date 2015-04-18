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

			Js.referenceAs<Action<Func<Func<IEnumerable<IResult>>, HTMLElement, BindingContext, Func<bool>>>>(@"(function(factory) {
    var orgApply = ko.bindingConventions.conventionBinders.button.apply;
    ko.bindingConventions.conventionBinders.button.apply = function(name, element, bindings, unwrapped, type, dataFn, bindingContext) {
        var handler = factory(unwrapped.bind(bindingContext.$data), element, bindingContext);

        dataFn = function() { return handler };
        orgApply(name, element, bindings, handler, type, dataFn, bindingContext);
    };
})")
                (InitActionMethodHandler);


			Js.referenceAs<Action<Func<Func<IEnumerable<IResult>>, HTMLElement, BindingContext, Func<bool>>>>(@"(function(factory) {
	ko.bindingHandlers.attach = {
		init: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
			var events = valueAccessor()
			for(var name in events) {
				events[name] = factory(events[name].bind(viewModel), element, bindingContext);
			}
			
			valueAccessor = function() {
				return events;
			};
			
			ko.bindingHandlers.event.init(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext);
		}
	};
})")(InitActionMethodHandler);
        }

        public static Func<bool> InitActionMethodHandler(Func<IEnumerable<IResult>> handler, HTMLElement element, BindingContext bindingContext)
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

	            return true;
            };
        }
    }
}
