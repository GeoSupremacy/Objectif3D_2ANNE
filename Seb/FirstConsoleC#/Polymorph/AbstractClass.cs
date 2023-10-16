using System;

namespace Polymorph
{
    public abstract class AbstractClass
    {
        public abstract int Property { get; set; }
        public abstract void Use();
        
        public virtual void Toto() {  }
        void Test() { }
    }
}
