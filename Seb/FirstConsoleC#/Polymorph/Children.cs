using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorph
{
    internal class Children :  Base
    {
        public override string Name
        {
            get => base.Name;
            protected set => base.Name = value;
        }
        public Children() : base() { }
        public Children(string name) : base(name) { }
        public Children(string name, string exp): base(name) { }
    }
}
