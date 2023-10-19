using System;
using System.Windows.Controls;


namespace DemoWPF
{
    abstract class Button
    {
        //public event Action OnCLick;
       protected System.Windows.Controls.Button button = null;
        public string TEXT { get; private set; }
        public string LINK { get; private set; }
        public double WIDTH { get;  set; }
        public double HEIGHT { get;  set; }

        public Button( string _tEXT, string _lINK, double _WIDTH, double _HEIGHT)
        {
            this.button = new System.Windows.Controls.Button();
            TEXT = _tEXT;
            LINK =_lINK;
            WIDTH = _WIDTH;
            HEIGHT = _HEIGHT;

            button.Height = HEIGHT;
            button.Width = WIDTH;
            button.Content = TEXT;
        }
        public abstract void Action();
    }
}
