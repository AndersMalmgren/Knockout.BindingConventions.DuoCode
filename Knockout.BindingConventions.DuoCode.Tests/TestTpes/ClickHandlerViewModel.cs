﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.BindingConventions.DuoCode.Tests.TestTpes
{
	public class ClickHandlerViewModel
	{
		private readonly bool canHandle;
		private bool success = false;

		public ClickHandlerViewModel(bool canHandle)
		{
			this.canHandle = canHandle;
		}

		public void Handle()
		{
			success = this.GetType().Name == typeof (ClickHandlerViewModel).Name;

		}

		public bool Success { get { return success; } }
	}
}