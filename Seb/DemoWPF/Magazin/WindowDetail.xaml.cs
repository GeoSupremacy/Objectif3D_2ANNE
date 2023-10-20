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

namespace Magazin
{
    /// <summary>
    /// Interaction logic for WindowDetail.xaml
    /// </summary>
    public partial class WindowDetail : Window
    {
        public WindowDetail()
        {
            InitializeComponent();
            NetworkAPI.SetStore();
          
            refrechButton.Click += (o, e) =>
            {
                dataGrid.SelectedValue = NetworkAPI.Info;

            };
        }
        
    }//
    


}//
