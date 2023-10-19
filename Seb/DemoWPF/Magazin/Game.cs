using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin
{
    public class Game
    {
        public uint GameID { get; set; }
        public string Title { get; set; }
        public string SteamAppID { get; set; }
        public string ExternalName { get; set; }
        public string InternalName { get; set; }
        public string CheapestDealID { get; set; }
        public double Price { get; set; }
        public double ReducePrice { get; set; }
        public double Savings { get; set; }
        public string Thumb { get; set; }

        public Game() { }
        public Game(string name, string description)
        {
            Name = name;
        }

    }
}
