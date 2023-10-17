using System;

namespace RPG_Correction
{
    public class Cell
    {
        CellBehaviour behaviour = null;
        public CellBehaviour Behaviour 
        { get => behaviour;
            private set
            {
                if(value == null) { return; }
                behaviour = value;
            }
        }
        public Cell()
        {
            Behaviour = GameBDD.GetRandomBehaviour() ;
        }
        public Cell(CellBehaviour _behaviour) 
        { 
            Behaviour =_behaviour;
        }
        public override string ToString()
        {
            return "[X]";
        }
    }
}
