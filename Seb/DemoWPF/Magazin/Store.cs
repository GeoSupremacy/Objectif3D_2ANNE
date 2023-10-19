using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin
{
    public class Store
    {
        public List<Game> ListGames { get; set; }
        public uint StoreID { get; set; }
        public string StoreName { get; set; }
        public bool isActive { get; set; }
        public string Banner { get; set; }
        public string Logo { get; set; }
        public string Icon { get; set; }
        
    }
}
