using System;
using System.Linq;
using DuoCode.Runtime;

// Set reflection-level (RTTI) for DuoCode compiler in order to find test methods using reflection

namespace Knockout.BindingConventions.DuoCode.Tests
{
    public static class TestRunner
    {
        static void Run() // HTML body.onload event entry point, see index.html
        {
			Binding.Init();

            var assembly = typeof(TestRunner).Assembly;
            foreach (var type in assembly.GetTypes())
            {
				var testAttribute = type.GetCustomAttributes(typeof(TestAttribute), false).Select(a => a as TestAttribute).FirstOrDefault();

				if(testAttribute != null)
                {
                    var methods = type.GetMethods();

                    var setup = methods.Single(m => m.GetCustomAttributes(typeof (TestSetup), false).Any());
                    var tests = methods.Where(m => m.GetCustomAttributes(typeof (TestMethodAttribute), false).Any());

                    foreach (var test in tests)
                    {
	                    var name = type.FullName + "." + test.Name;
						var runner = new Action(() =>
                        {
                            var instance = type.GetConstructors()[0].Invoke(new object[0]);
							TestHelper.TestFixture(testAttribute.Tag, testAttribute.Convention, (selector, c) => setup.Invoke(instance, new [] { new TestContext(selector, c),  }), () => test.Invoke(instance, new object[0] ));

                        });

						if(testAttribute.Async)
							QUnit.asyncTest(name, runner);
						else
							QUnit.test(name, runner);
                    }
                }
            }
        }
    }

	public class TestContext : IDisposable
	{
		private readonly JquerySelector element;
		private readonly Action clean;
		public TestContext(JquerySelector element,  Action clean)
		{
			this.element = element;
			this.clean = clean;
		}

		public JquerySelector Element { get { return element; } }

		public void Dispose()
		{
			clean();
		}
	}
}
