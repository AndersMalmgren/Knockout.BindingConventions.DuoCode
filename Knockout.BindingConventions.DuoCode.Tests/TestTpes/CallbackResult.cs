using System;

namespace Knockout.BindingConventions.DuoCode.Tests.TestTpes
{
	public class CallbackResult : Result
	{
		private readonly Action callback;
		public CallbackResult(Action callback)
		{
			this.callback = callback;
		}

		public override void Execute(ResultContext context)
		{
			callback();

			base.Execute(context);
		}
	}
}