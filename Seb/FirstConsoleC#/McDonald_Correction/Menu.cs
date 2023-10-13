using System;

namespace McDonald_Correction
{
    internal class Menu
    {
        public event Action OnShowMenu = null;
        public event Action<int> OnSelection = null;

        string title = string.Empty;
        protected MenuData[] data = null;
       public Menu(string _title, MenuData[] _data)
        {
           title = $"***{_title}****\n";
           data = _data;
            OnShowMenu += Selection;
        }

        public virtual void ShowMenu() 
        { 
            Console.WriteLine(title);
            for (int i = 0; i < data.Length; i++)  
            {
                Console.WriteLine($" Recipe: {i+1}--{ data[i].Label}");
            }
            
            OnShowMenu?.Invoke();
        }
        public virtual void Selection()
        {
            bool _isValid = int.TryParse(Console.ReadLine(), out int _select);
            while (!_isValid || !InputCheck(_select, data.Length))
            { 
                Console.WriteLine("Wrong choise!!");
                Selection();
            }
            int _index = _select - 1;
            OnSelection?.Invoke(_index);
        }
        public virtual bool InputCheck(int _select, int _dataSize) => _select>=1 && _select<= _dataSize;
    }
}
