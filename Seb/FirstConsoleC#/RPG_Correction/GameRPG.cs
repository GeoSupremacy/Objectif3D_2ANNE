using System;

namespace RPG_Correction
{
    internal class GameRPG
    {
        Player payer = new Player();
        Grid grid = new Grid(10);

        public GameRPG() 
        {
            if (!grid)
                return;
            grid.DrawGrid();
            Console.WriteLine("TEST");
            Player.SetGameGrid(grid);
            Player.Move(0, 0);
        }
    }
}
