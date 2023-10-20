using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Magasin_Correction
{
    public class Image
    {
        public string Logo { get; set; }
        public string LogFormat => $"https://www.cheapshark.com{Logo}";
        public BitmapImage FilaLogo { get; set; }
        public void GetLogo()
        {
            FilaLogo = new BitmapImage();
            FilaLogo.BeginInit();
            FilaLogo.UriSource = new Uri(LogFormat);
            FilaLogo.EndInit();
        }
    }
    public class Store
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; } 
         public Image Images { get; set; }
       
    }
}
