using DuoCode.Runtime;

namespace Knockout.BindingConventions.DuoCode
{
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