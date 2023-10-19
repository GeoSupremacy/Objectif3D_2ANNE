using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin
{
    public class Game
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Game() { }
        public Game(string name, string description)
        {
            Name = name;
        }

    }
}
