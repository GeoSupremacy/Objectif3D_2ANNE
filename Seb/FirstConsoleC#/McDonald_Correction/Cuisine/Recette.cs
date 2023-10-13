using McDonald_Correction;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace McDonald_Correction
{
    internal class Recette
    {
        #region F/P
        public string Name { get; private set; } = string.Empty;
        public Ingredient[] ingredients { get; private set; } = null;
        public TimeSpan MinuteTimer { get; private set; }

        #endregion F/P
        public Recette(string _name, Ingredient[] _ingredients, int _timer = 1)
        {
            Name = _name;
            ingredients = _ingredients;
            MinuteTimer = TimeSpan.FromSeconds(_timer);

        }
        public void Prepare()
        {
            // if (!CheckIngredient())
            //    Console.WriteLine($"Rupture de stock {Name}...");
            Console.Clear();
            Console.WriteLine($"Préparation de {Name}...");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"Utilisation de: {ingredients[i].Name}- x{ingredients[i].Qty}\n");

            }

        }
        public bool CheckIngredient(int _rest)
        {
            for (int i = 0; i < ingredients.Length;)
                if (_rest < ingredients[i].Qty)
                    return false;

            return true;
        }


    }



 }
