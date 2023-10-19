using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin
{
    public class Deal
    {
       
        public string Title { get; set; }
        public string MetacriticLink { get; set; }
        public uint DealdID{get ;set ;}
        public double SalePrice { get; set; }
        public double NormalPrice { get; set; }
        public string isOnSale { get; set; }
        public double Savings { get; set; } = 0;
        public int MetacriticScore { get; set; }
        public string SteamRatingText { get; set; }
        public int steamRatingPercent { get; set; }
        public uint ReleaseDate { get; set; }
        public uint LastChange { get; set; }
        public uint SteamRatingCount { get; set; }
        public double DealRating { get; set; }
        public Game Game { get; set; }
        public Store Store { get; set; }
    }
}
