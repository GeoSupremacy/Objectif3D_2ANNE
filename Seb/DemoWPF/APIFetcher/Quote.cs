using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFetcher
{
    public class Quote
    {
        public string Sentence { get; set; }
        public Character Character { get; set; }
    }
    public class Character
    {
        public string Name { get; set; }
        public string slug { get; set; }
        public House House { get; set; }
    }
    public class House
    {
        public string Name { get; set; }
        public string slug { get; set; }
    }
}

