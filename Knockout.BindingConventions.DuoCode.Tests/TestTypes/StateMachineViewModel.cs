using System;
using System.Collections.Generic;

namespace Knockout.BindingConventions.DuoCode.Tests.TestTypes
{
	public class StateMachineViewModel
	{
		private readonly Action callback;

		public StateMachineViewModel(Action callback)
		{
			this.callback = callback;
		}

		public IEnumerable<IResult> ActionMethod()
		{
			yield return new CallbackResult(callback);
		}

	}
}