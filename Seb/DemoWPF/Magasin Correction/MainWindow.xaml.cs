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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Magasin_Correction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int currentPage = 0;
        public MainWindow()
        {
            InitializeComponent();
            InitUi();

        }
        void InitUi()
        {
            NetworkFetcher.OnBeginDownload += () => OnLoaddingEvent(true);
            NetworkFetcher.OnEndDownload += () => OnLoaddingEvent(false);
            NetworkFetcher.OnFailDownload += () => OnLoaddingEvent(false);

            NetworkFetcher.OnDealIsDowLoad += ReadDatas;
            NetworkFetcher.OnStoreIsDowLoad += ReadStore;
            NetworkFetcher.GetAllStores();

            //prevButton.IsEnabled = currentPage > 0;
            prevButton.Click += (o, e) =>
            {
                SetPreviousPage();
                NetworkFetcher.GetAllDeals(currentPage);
                
            };
            nextButton.Click += (o, e) =>
            {
                NextPreviousPage();
                NetworkFetcher.GetAllDeals(currentPage);
            };
            NetworkFetcher.OnDealIsDowLoad += (d) =>
            {
                dealList.ItemsSource = d;
            };
            fetchButton.Click += (o, e) =>
            {
                NetworkFetcher.GetAllDeals();
            };
        }
        void OnLoaddingEvent(bool _isLoading)
        {
            fetchButton.Content = _isLoading ? "Loading datas...": "Fetch Deal!";
            fetchButton.IsEnabled = !_isLoading;
        }
        void ReadDatas(Deal[] _datas)
        {
            for (int i = 0; i < _datas.Length; i++) 
                _datas[i].GetImage();

            dealList.ItemsSource = _datas;
            dealsDatabaseText.Content = ($"All store loaded: {_datas.Length}");
            dealsDatabaseText.Foreground = _datas.Length > 0 ? new SolidColorBrush(Color.FromRgb(0, 255, 0)) : new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }
        void ReadStore(Store[] _stores)
        {
            for (int i = 0; i < _stores.Length; i++)
            { 
                _stores[i].Images.GetLogo();
                DataBase.AddStore(_stores[i]);
            }
           storeDatabaseText.Content =($"All store loaded: {_stores.Length}");
           storeDatabaseText.Foreground = _stores.Length > 0 ? new SolidColorBrush(Color.FromRgb(0, 255, 0) ): new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }
        void NextPreviousPage() => currentPage++;
        void SetPreviousPage() 
        { 
            currentPage--;
            currentPage = currentPage < 0 ? 0 : currentPage;
           
        }
    }//
}//
