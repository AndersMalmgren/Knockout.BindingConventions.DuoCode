using DuoCode.Runtime;

namespace Knockout.BindingConventions.DuoCode
{
    [Js(Extern = true)]
    public class BindingContext
    {
        [Js(Name = "$data")]
        public object Data;

        [Js(Name = "$parent")]
        public object Parent;

        [Js(Name = "$parents")]
        public object[] Parents;

        [Js(Name = "$parentContext")]
        public object ParentContext;

        [Js(Name = "$rawData")]
        public object RawData;

        [Js(Name = "$root")]
        public object Root;
    }
}