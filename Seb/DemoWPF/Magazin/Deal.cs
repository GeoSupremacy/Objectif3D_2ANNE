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
        public uint DealdID{get ;set ;}
        public Store[] StoreList { get; set; }
        public Game[] GameList { get; set; }
        public bool isOnSale { get; set; }
        public int PageNumber { get; set; }
        public int MetacriticScore { get; set; }
        public int SteamRatingText { get; set; }
        public int SteamRatingCount { get; set; }
        public double DealRating { get; set; }
        public  int PageSize 
        { 
            get=> PageSize; 
            set => value = value > 60 ? value = 60 : value = value; 
        }
        public Deal() 
        {
            
            PageSize = 60;
            PageNumber = 0;
        }
    }
}
