using System;

namespace Polymorph
{
    internal class ChildAbstract :AbstractClass
    {
        public override int Property { get; set; }
        public override void Use() 
        { 
            
        }
        public sealed override void Toto() { base.Toto(); }
    }
}
