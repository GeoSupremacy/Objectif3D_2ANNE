using System;

namespace RPG
{
    internal class Player
    {
        public int X { get; set; } = 0; public int Y { get;  set; }= 0;
       public Player() { }
       public void Movement()
        {
            Console.WriteLine($"Position player: X:{X}-Y:{Y}");
            Console.WriteLine("Move with ZQSD");

            string controle = Console.ReadLine();
            switch (controle) { 
                case "z":
                    Y++;
                    break;
                case "q":
                    X--;
                    break;
                case "s":
                    Y--;
                    break;
                case "d":
                    X++;
                    break;
                default:
                    Console.WriteLine("Wrong controle");
                    break;
            }
            controle = string.Empty;
        }
        public void SetPosition( Map _currentMap) {
            for (int i = 0; i < _currentMap.Width; i++)
            {
                for (int j = 0; j < _currentMap.Height; j++)

                {
                    if ("PL" == _currentMap.Case[i, j])
                    {
                        X = i;
                        Y = j;
                    }
                }
            }
        }
        /*
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int PlayerId { get; set; }
        */
    }
}
