using System;

namespace RPG_Correction
{
    public abstract class CellBehaviour
    {
        public abstract void Behaviour(Player _p);
        public override string ToString() => "[X]";
        
    }//
}
