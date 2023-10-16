using System;

namespace RPG
{
    internal class Map
    {
        int playerX, playerY = 0;
         DataMap map = null;
        public int Width { get; private set; } = 0;
        public int Height { get; private set; } = 0;
        public string[,] Case 
        {
            get;
            set ; 
        }
        public Map() 
        {
            map = new DataMap();
            Case = map.Map;
            Width = map.Map.GetLength(0);
            Height = map.Map.GetLength(1);
        }
        public void AddGrid() 
        {
          
            Console.Clear();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if ("PL" == Case[i, j])
                    {
                        playerX = i;
                        playerY = j;
                    }
                    Console.Write(string.Format(Case[i, j]));
                } 
                Console.WriteLine();
            }
        }
        public void SetPlayer(Player _player) 
        {
            if (_player.X >= Width || _player.Y >= Height && _player.X <= 0 || _player.Y <= 0)
            {
                _player.X = playerX;
                _player.Y =playerY ;
                return;
            }
            int rowLength = map.Map.GetLength(0);
            int colLength = map.Map.GetLength(1);
            for (int i = 0; i < rowLength; i++)
                for (int j = 0; j < colLength; j++)
                    if ("PL"==Case[i, j])
                    {
                        string _temp = Case[_player.X, _player.Y];
                        Case[i, j] = _temp;
                        Case[_player.X, _player.Y] = "PL";
                        break;
                    }
            
        }
    }
}
// P 