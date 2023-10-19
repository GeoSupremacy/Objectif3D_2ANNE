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
        public string SteamAppID { get; set; }
        public string External { get; set; }
        public string InternalName { get; set; }
        public string CheapestDealID { get; set; }
        public double Cheapest { get; set; }
        public string Thumb { get; set; }
    }
}
