using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.BindingConventions.DuoCode.Tests.TestTypes
{
	public class EventViewModel
	{
		private readonly Action callback;
		public string value;

		public EventViewModel(Action callback)
		{
			this.callback = callback;
		}

		public IEnumerable<IResult> OnKeyDown()
		{
			Console.WriteLine("keydown");

			yield return new CallbackResult(callback);
		}
	}
}