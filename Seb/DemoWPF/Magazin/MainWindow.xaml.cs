using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Magazin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 2;
        public static List<Deal> listdeal;
        public MainWindow()
        {
            InitializeComponent();
            NetworkAPI.GetGame();
            listdeal = NetworkAPI.listDeal;
            refrechButton.Click += (o, e) =>
            {
                i = 2;

              Data();

            };
            rightButton.Click += (o, e) =>
            {
                i++;
                Data();
            };
            leftButton.Click += (o, e) =>
            {
                
                i = i-- <= 2 ? 2 : i--;
                Data();
            };
            
            dataGrid.MouseDoubleClick += (o, e) =>
            {
               // NetworkAPI.index = dataGrid.TabIndex;
                WindowDetail _wd = new WindowDetail();
                _wd.Show();
            };

           
        }//

        void Data() 
        {
            
            NetworkAPI.SetGame(i);
            dataGrid.ItemsSource = NetworkAPI.listDeal;
        }
    }
}
