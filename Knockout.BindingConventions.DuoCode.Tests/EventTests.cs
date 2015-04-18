using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Knockout.BindingConventions.DuoCode.Tests.TestTypes;

namespace Knockout.BindingConventions.DuoCode.Tests
{
	[Test("INPUT", "value", true)]
	public class When_attaching_a_result_handler_to_a_event
	{
		private TestContext testContext;

		[TestSetup]
		public EventViewModel Setup(TestContext context)
		{
			testContext = context;
			context.Element.Attribute("data-bind", "attach: { keydown: OnKeyDown }");

			return new EventViewModel(() => {
				QUnit.start();
				QUnit.ok(true);
				context.Dispose();

			});
		}

		[TestMethod]
		public void It_should_invoke_result_handler_on_keydown()
		{
			testContext.Element.KeyDown();
		}
	}
}