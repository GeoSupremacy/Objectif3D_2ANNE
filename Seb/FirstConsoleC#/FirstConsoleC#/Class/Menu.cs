using System;

namespace FirstConsoleC_.CalculatorSystem
{
    internal class Menu
    {

     #region f/p
        string menuTitle = string.Empty;
        string[] choices = null;
        Func<int, int, int>[] actions = null;
        public  Action[] actionAc = null;
        public event Action OnShowMenu;
        public event Action<int>OnSelection = null;
     #endregion
     #region construc/destruc
        public Menu()
        {
            menuTitle = "Base menu";
            choices = new string[0];
            actions = null;
        }
        public Menu(string _menuTitle, string[] _tab, Action[] _actions)
        {
            menuTitle = _menuTitle;
            choices = _tab;
            actionAc = _actions;
            OnShowMenu += Selection;
            Display();
        }
        public Menu(string _menuTitle, string[] _tab, Func<int, int, int>[] _actions)
        {
            menuTitle = _menuTitle;
            choices = _tab;
            actions = _actions;
            OnShowMenu += Selection;
            Display();
        }
     #endregion
     #region Method
        public void Display() 
        {
            Console.WriteLine(menuTitle);
            for (int i = 0; i < choices.Length; i++)  
                Console.WriteLine($"{i+1}-{choices[i]}");
            OnShowMenu?.Invoke();
            
        }
        public void Display(Action _callback)
        {
            Console.WriteLine(menuTitle);
            for (int i = 0; i < choices.Length; i++)
                Console.WriteLine($"{i + 1}-{choices[i]}");
            _callback?.Invoke();

        }
        void Selection()
        {
            Console.WriteLine("Select: ");
           
            bool _isValid = int.TryParse(Console.ReadLine(), out int _result);
           
            while (!_isValid || !InputCheck(_result, choices.Length))
                Selection();

            int _index = _result - 1;
            int? _resultSelect = actions[_index] ?.Invoke(10, 5);
            Console.WriteLine($"Result {_resultSelect}");
            OnSelection?.Invoke(_index);
            Selection();
        }
        bool InputCheck(int _input, int _sizeMax) => _input >= 1 && _input <= _sizeMax;
     #endregion
    }
}
/*  string _select = Console.ReadLine();
             int _capacity = 0;
             float _max = 10.56f;
             _capacity = (int)_max;
             _max = _capacity;
             string _a = "1qsdqd";
             // int _result = 0;
             // _result = int.Parse(_a);
            if (!_isValid) return;
           */

/*switch (_select)
            {
                case "1":
                { 
                    Console.WriteLine("Result");
                    Display();
                    break;
                }
                default:
                    Selection();
                break;
            }
            */