using System;

namespace Knockout.BindingConventions.DuoCode.Tests
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class TestMethodAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TestAttribute : Attribute
    {
		public string Tag { get; set; }
		public string Convention { get; set; }
		public bool Async { get; set; }

	    public TestAttribute(string tag, string convention)
	    {
		    Tag = tag;
		    Convention = convention;
	    }

		public TestAttribute(string tag, string convention, bool async)
		{
			Tag = tag;
			Convention = convention;
			Async = async;
		}
    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class TestSetup : Attribute
    {
    }
}
