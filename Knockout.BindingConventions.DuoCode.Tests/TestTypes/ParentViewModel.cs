using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.BindingConventions.DuoCode.Tests.TestTypes
{
    public class ParentViewModel
    {
        private readonly SubViewModel subView;

        public ParentViewModel()
        {
            subView = new SubViewModel();
        }
    }
}