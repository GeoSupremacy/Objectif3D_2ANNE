using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace RPG_Correction
{
    internal class HealCellBehaviour : CellBehaviour
    {
        public override void Behaviour(Player _p)
        {
            Console.WriteLine("HEAL");
        }
        public override string ToString() { return "[H]"; }
    }//
    
}
