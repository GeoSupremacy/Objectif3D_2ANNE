using System;
using System.Timers;

namespace McDonald
{
    internal class Menu
    {
        
        Command commande = null;
        public  Menu()
        {
            commande = new Command();
            commande.ActiveTimer += (x, y) => 
            {
                new TimerCommande(x, y);
            };
            ShowMenu();
            Choose();
        }
        void ShowMenu()
        {
            for (int i = 0; i < commande.GetCommande().Length; i++)
                Console.WriteLine($"{i+1} - {commande.GetCommande()[i].Name()}");
        }
        void Choose() 
        {
            
            Console.WriteLine($"Select: ");
            bool _isValid = int.TryParse(Console.ReadLine(), out int _result);

            while (!_isValid || !InputCheck(_result, commande.GetCommande().Length))
            {
                Console.Clear();
                Console.WriteLine($"Wrong commande! ");
                ShowMenu();
                Choose();
            }

            commande.ActiveTimer?.Invoke(commande.GetCommande()[_result-1].Preparation(), commande.GetCommande()[_result - 1].Name());
            // Console.WriteLine(TimerCommande.GetCurrent());
            //commande.ActiveTimer?.EndInvoke(commande.GetPreparation()[_result - 1], commande.GetCommande()[_result - 1]);
            Console.Clear();
            ShowMenu();
            Choose();

        }
        bool InputCheck(int _input, int _length) => _input >= 1 && _input <= _length;
      
    }
}
