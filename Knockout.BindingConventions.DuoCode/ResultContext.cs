using DuoCode.Dom;

namespace Knockout.BindingConventions.DuoCode
{
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
}