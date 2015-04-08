using System;

namespace Knockout.BindingConventions.DuoCode
{
    public interface IResult
    {
        void Execute(ResultContext context);
        event EventHandler<ResultCompletionEventArgs> Completed;
    }
}