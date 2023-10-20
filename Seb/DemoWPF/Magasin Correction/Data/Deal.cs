using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Magasin_Correction
{
    internal class Deal
    {
        public string Title { get; set; }
        public float SalePrice { get; set; }
        public float NormalPrice { get; set; }
        public string SalePriceFormat => $"{SalePrice} $({Utils.GetEurosFromDollardToString(SalePrice)})";
        public string SaleNormalPrice => $"{NormalPrice} $({Utils.GetEurosFromDollardToString(NormalPrice)})";
        public float Savings { get; set; }
        public string SavingsFormat => $"{Savings.ToString("0")} %";
        public string Thumb { get; set; }
        public BitmapImage Image { get; set; } = new BitmapImage();
        public void GetImage()
        {
            Image.BeginInit();
            Image.UriSource = new Uri(Thumb);
            Image.EndInit();
        }
    }
}
