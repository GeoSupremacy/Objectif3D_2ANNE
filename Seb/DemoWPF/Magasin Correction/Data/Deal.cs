using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Magasin_Correction
{
    public class Deal
    {
        public string Title { get; set; }
        public float SalePrice { get; set; }
        public float NormalPrice { get; set; }
        public float DetailPrice { get; set; }
        public float RetailPrice { get; set; }
        public  int StoreID { get; set; }
        public string GameID { get; set; }
        public string DealID { get; set; }
        public float Price { get; set; }
        public string PriceFormat => $"{Price} $({Utils.GetEurosFromDollardToString(Price)})";
        public string SalePriceFormat => $"{SalePrice} $({Utils.GetEurosFromDollardToString(SalePrice)})";
        public string SaleNormalPrice => $"{NormalPrice} $({Utils.GetEurosFromDollardToString(NormalPrice)})";
        public float Savings { get; set; }
        public string SavingsFormat => $"{Savings.ToString("0")} %";
      //  public float SavingDeal => (SalePrice / RetailPrice);
       // public string SavingDealFormat => $"{Savings.ToString("0")}";
        public string Thumb { get; set; }
        public BitmapImage Image { get; set; } = new BitmapImage();
        public Store Store { get; set; }   
        public void GetImage()
        {
            Image.BeginInit();
            Image.UriSource = new Uri(Thumb);
            Image.EndInit();
        }

        public override string ToString() => $"{Title} {SalePriceFormat}";

        public Deal() { }
    }
}
