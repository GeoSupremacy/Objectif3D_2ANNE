using System;

namespace RPG_Correction
{
    internal class Grid
    {
        int size = 2;
        Cell[,] cells = null; //ou Cell[][]
        public Grid(int _size)
        {
            size = _size;
            cells = new Cell[size ,size];
            Generate();
        }
        void Generate()
        {
            for (int i = 0; i < size; i++) 
                for(int j = 0; j < size; j++)
                    cells[i,j] = new Cell();
        }

       public void DrawGrid()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    Console.WriteLine(cells[i, j].ToString());
        }
    }

    public Cell Get(int _x, int _y)
    {
        return cells[_x, _y];
    }
    public static bool operator !(Grid _grid) => _grid ==null;
}//
