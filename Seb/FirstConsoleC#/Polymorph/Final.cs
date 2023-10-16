using System;

namespace Polymorph
{
    internal class Final :IDamage
    {
        public int Life {get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void ApplyDammage(int _dmg)
        { 
            throw new NotImplementedException(); 
        }
        public void First()
        { throw new NotImplementedException(); }

        public int Last(int _value) { throw new NotImplementedException(); }
    }
}
