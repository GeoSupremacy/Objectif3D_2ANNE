using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Magasin_Correction
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        public DetailWindow()
        {
            InitializeComponent();
        }
        public DetailWindow(Deal _deal)
        {
            InitializeComponent();
            NetworkFetcher.OnDetailsIsDowLoad += ReadDetails;
            NetworkFetcher.GetAllDetails(_deal);
            gamePicture.Source = _deal.Image;
            gameTitle.Content = _deal.Title;
        }
        void ReadDetails(GameInfo _gameInfo)
        {
            for (int i = 0; i < _gameInfo.Deals?.Length; i++)
            {
                Store _store = DataBase.AllStoresDB[_gameInfo.Deals[i].StoreID];
                _gameInfo.Deals[i].Store = _store;
               
            }
            detailsGrid.ItemsSource = _gameInfo.Deals;
        }
    }
}
