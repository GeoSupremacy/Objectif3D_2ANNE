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

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        Explorer explorer = new Explorer();
        FileData currentSelection = null;
        public BrowserWindow()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            refreshButton.Click += (o, e) =>
            {
                filesList.ItemsSource = explorer.GetAllFiles(rootBox.Text);
                dataGrid.ItemsSource = explorer.GetAllFiles(rootBox.Text);
            };
            filesList.SelectionChanged += (o, e) => { OnSelection(); };
            dataGrid.SelectionChanged += (o, e) => { OnSelection(); };
            dataGrid.MouseDoubleClick += (o, e) => 
            {
                if (!currentSelection)
                    return;
                currentSelection?.Open();
            };
            openButton.Click += (o, e) =>
            {
                if (!currentSelection)
                    return;
                currentSelection?.Open();
            };

        }
        void OnSelection()
        { 
            FileData _data = (FileData)dataGrid.SelectedValue;
            openButton.IsEnabled = _data != null;
            currentSelection = _data;
        }
        //C:\Users\GUIC1203\Documents
    }
}
