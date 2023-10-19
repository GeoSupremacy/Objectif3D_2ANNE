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
        public Store Store { get; set; } = null;
        public int PageNumber { get; set; }
        public  int PageSize 
        { 
            get=> PageSize; 
            set => value = value > 60 ? value = 60 : value = value; 
        }
        public Deal() 
        {
            Store = new Store();
            PageSize = 60;
            PageNumber = 0;
        }
    }
}
