using System;
using System.Runtime.InteropServices;

namespace Polymorph
{
    internal class Base
    {
        public virtual string Name { get;protected set; }
        public Base() { }
        public Base(string _name) { Name = _name; }

        public void Method() { }
        public void Method(string _name) { }
       void Private(string _name) { }
}
}
