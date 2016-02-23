using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Knockout.BindingConventions.DuoCode.Tests.TestTypes;
using DuoCode.Runtime;

namespace Knockout.BindingConventions.DuoCode.Tests
{
    public abstract class TemplateTest
    {
        protected TestContext context;
        protected JquerySelector template;
        protected const string expected = "My template content";


        protected void InjectTemplate(TestContext testContext, string modelName)
        {
            context = testContext;
            template = context
                .Selector(string.Format("<script id='{0}' type='text/html'>{1}</script>", modelName.Replace("ViewModel", "View"), expected))
                .AppendTo(context.Selector("body"));
        }

        protected void Clean()
        {
            context.Dispose();
            template.Remove();
        }
    }

    [Test("DIV", "subView")]
    public sealed class When_binding_view_model_to_a_view : TemplateTest
    {

        [TestSetup]
        public ParentViewModel<SubViewModel> Setup(TestContext testContext)
        {
            InjectTemplate(testContext, typeof(SubViewModel).FullName);
            return new ParentViewModel<SubViewModel>(new SubViewModel());
        }



        [TestMethod]
        public void It_should_have_rendered_correct_view()
        {
            QUnit.equal(context.Element.Html(), expected);
            Clean();
        }
    }
}