using System.Linq;
using DuoCode.Runtime;
using Knockout.BindingConventions.DuoCode.Tests.TestTpes;

namespace Knockout.BindingConventions.DuoCode.Tests
{

	[Test("BUTTON", "Handle")]
	public sealed class When_binding_a_button_
	{
		private TestContext context;
		private ClickHandlerViewModel model;

		[TestSetup]
		public ClickHandlerViewModel Setup(TestContext testContext)
		{
			context = testContext;
			return model = new ClickHandlerViewModel(true);
		}

		[TestMethod]
		public void It_should_have_correct_reference()
		{
			context.Element.Click();
			QUnit.ok(model.Success);
			context.Dispose();
		}
	}

	[Test("BUTTON", "Handle")]
	public sealed class When_binding_a_button_with_a_guard
	{
		private TestContext context;

		[TestSetup]
		public ClickHandlerViewModel Setup(TestContext testContext)
		{
			context = testContext;
			return new ClickHandlerViewModel(false);
		}

		[TestMethod]
		public void It_should_have_correct_reference()
		{
			QUnit.ok(!context.Element.Is(":enabled"));
			context.Dispose();
		}
	}

    [Test("BUTTON", "ActionMethod", true)]
    public sealed class When_binding_and_button_to_action_method
    {
	    private TestContext context;

	    [TestSetup]
		public StateMachineViewModel Setup(TestContext testContext)
	    {
		    context = testContext;
		    return new StateMachineViewModel(() =>
		    {
			    QUnit.start();
				QUnit.ok(true);
				context.Dispose();
		    });
	    }

	    [TestMethod]
        public void It_should_execute_results_when_clicking()
        {
			context.Element.Click();
        }
    }
}