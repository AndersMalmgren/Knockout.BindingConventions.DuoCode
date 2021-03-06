﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuoCode.Dom;
using DuoCode.Runtime;

namespace Knockout.BindingConventions.DuoCode.Tests
{
	[Js(Name = "ko", Extern = true)]
	public static class TestHelper
	{
		//tag, convention, model, test

		[Js(Name="testFixture")]
		public static extern void TestFixture(string tag, string convention, Func<JquerySelector, Action, object> setup, Action test);
	}

	[Js(Extern = true, Name="$")]
	public class JquerySelector
	{
		[Js(Name = "click")]
		public extern void Click();

		[Js(Name = "click")]
		public extern void Click(Action handler);

		[Js(Name = "keydown")]
		public extern void KeyDown();


		[Js(Name = "is")]
		public extern bool Is(string selector);

		[Js(Name = "attr")]
		public extern bool Attribute(string name, string value);

        [Js(Name = "parent")]
	    public extern JquerySelector Parent();

        [Js(Name = "html")]
        public extern void Html(string html);

        [Js(Name = "html")]
        public extern string Html();

        [Js(Name = "append")]
	    public extern JquerySelector Append(JquerySelector content);

        [Js(Name = "appendTo")]
        public extern JquerySelector AppendTo(JquerySelector content);

        [Js(Name = "remove")]
        public extern void Remove();
	}
}