using System;

namespace RPG_Correction
{
    internal class GameBDD
    {
        public static CellBehaviour[] Behaviours
        {
            get;
            set;
        } = new CellBehaviour[]
        {
            new AttackCellBehaviour(),
            new HealCellBehaviour(),
        };
        public static CellBehaviour GetRandomBehaviour() 
        { 
            int _index = new Random().Next(0, Behaviours.Length);
            return Behaviours[_index]; 
        }
    }
}
