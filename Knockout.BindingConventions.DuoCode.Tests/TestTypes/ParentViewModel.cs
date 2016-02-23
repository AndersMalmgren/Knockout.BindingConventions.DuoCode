using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.BindingConventions.DuoCode.Tests.TestTypes
{
    public class ParentViewModel<TSubModel>
    {
        private readonly TSubModel subView;

        public ParentViewModel(TSubModel model)
        {
            subView = model;
        }
    }
}