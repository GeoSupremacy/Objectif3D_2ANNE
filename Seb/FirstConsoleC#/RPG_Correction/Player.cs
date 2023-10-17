using System;

namespace RPG_Correction
{
    public class Player : IStats
    {
        Grid grid = null;
        public int Life { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Damages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Player() { }
        public void SetGameGrid(Grid _grid) { grid = _grid; }
        public void Move(int _x, int _y)
        {
            Cell _c = grid?.Get(_x, _y);
            _c.Behaviour.Behaviour(this);

        }

        public void SetLife(int _life)
        {
            throw new NotImplementedException();
        }
        public void SetDamages(int _life)
        {
            throw new NotImplementedException();
        }
    }
}
