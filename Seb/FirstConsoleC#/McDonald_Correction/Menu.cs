using System;

namespace McDonald_Correction
{
    internal class Menu
    {
        public event Action OnShowMenu = null;
        public event Action<int> OnSelection = null;

        string title = string.Empty;
        MenuData[] data = null;
       public Menu(string _title, MenuData[] _data)
        {
            this.title = _title;
            this.data = _data;
        }

        public virtual void ShowMenu() 
        { 
            Console.WriteLine($"***{title}****\n");
            OnShowMenu?.Invoke();
        }
        public virtual void Selection() 
        { 
        }
    }
}
