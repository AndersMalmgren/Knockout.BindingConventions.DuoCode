using System;

namespace Knockout.BindingConventions.DuoCode.Tests.TestTpes
{
	public abstract class Result : IResult
	{
		public virtual void Execute(ResultContext context)
		{
			OnCompleted(this, new ResultCompletionEventArgs());
		}

		protected virtual void OnCompleted(object sender, ResultCompletionEventArgs e)
		{
			if(Completed != null)
				Completed(sender, e);
		}

		public event EventHandler<ResultCompletionEventArgs> Completed;
	}
}