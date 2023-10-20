using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         public MainWindow()
        {
            
            InitializeComponent();
            Init();
        }
        void Init() 
        { 
            apIUnreal.Click += (e, o) => Open("aPIUnreal");
            gitUp.Click += (e, o) => Open("gitUp");
            mixamo.Click += (e, o) => Open("mixamo");
            maya.Click += (e, o) => Open("maya");
            visualInstaller.Click += (e, o) => Open("visualInstaller");
            visualStudio.Click += (e, o) => Open("visualStudio");
            gitUpDestock.Click += (e, o) => Open("gitUpDestock");
            epicGamesLauncher.Click += (e, o) => Open("epicGamesLauncher");
            unrealEngine.Click += (e, o) => Open("unrealEngine");

            window.Click += (e, o) => 
            { 
                BrowserWindow _brw = new BrowserWindow();
                _brw.Show();
            };
            //Open Windown => Create new Windi + Show
        }
        void Open(string _key) 
        {
            bool _isValid = URLBdd.URL.ContainsKey(_key);
            if (!_isValid) return;
            Process.Start(URLBdd.URL[_key]);
        }

        private void apIUnreal_Click(object sender, RoutedEventArgs e)
        {

        }
        /* private void UnrealAPI_Click(object sender, RoutedEventArgs e)
{
    Process.Start(linkUnreal);
}
private void Git_Click(object sender, RoutedEventArgs e)
{
    Process.Start(linkGit);
}
private void Mixamo_Click(object sender, RoutedEventArgs e)
{
    Process.Start(linkMixamo); 
}
private void VisualStudio_Click(object sender, RoutedEventArgs e)
{
    Process.Start(linkVisualStudio);
}
private void MayaApli_Click(object sender, RoutedEventArgs e)
{
    Process.Start(linkApliMaya);
}
private void VisualInstaller_Click(object sender, RoutedEventArgs e)
{
    Process.Start(linkVisualInstaller);
}
private void GitUpDestock_Click(object sender, RoutedEventArgs e)
{
    Process.Start(linkGitUpDestock);
}
private void EpicGamesLauncher_Click(object sender, RoutedEventArgs e)
{
    Process.Start(linkEpicGamesLauncher);
}
private void UnrealEngine_Click(object sender, RoutedEventArgs e)
{
    MessageBox.Show("Not found");
}*/
        //private void P4V_Click(object sender, RoutedEventArgs e)
        //{
        //Process.Start(linkVisualInstaller);
        //}
    }
}
