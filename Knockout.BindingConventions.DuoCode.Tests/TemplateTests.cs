using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Knockout.BindingConventions.DuoCode.Tests.TestTypes;

namespace Knockout.BindingConventions.DuoCode.Tests
{
    [Test("DIV", "subView")]
    public sealed class When_binding_view_model_to_a_view
    {
        private TestContext context;
        private JquerySelector template;
        private const string expected = "My template content";

        [TestSetup]
        public ParentViewModel Setup(TestContext testContext)
        {
            context = testContext;
            template = context
                .Selector(string.Format("<script id='{0}' type='text/html'>{1}</script>", typeof(SubViewModel).FullName.Replace("ViewModel", "View"), expected))
                .AppendTo(context.Selector("body"));

            return new ParentViewModel();
        }

        [TestMethod]
        public void It_should_have_rendered_correct_view()
        {
            QUnit.equal(context.Element.Html(), expected);
            context.Dispose();
            template.Remove();
        }
    }
}