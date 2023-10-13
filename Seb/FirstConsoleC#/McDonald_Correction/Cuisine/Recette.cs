using System;

namespace McDonald_Correction
{
    internal class Recette
    {
        public string Name { get; private set; } = string.Empty;
        public Ingredient[] ingredients { get; private set; } = null;
        public TimeSpan MinuteTimer { get; private set; }
        public Recette( string _name, Ingredient[] _ingredients, int _timer =1) 
        {
            Name = _name;
            ingredients =_ingredients;
            MinuteTimer = TimeSpan.FromMinutes(_timer);

        }
        public void Prepare() 
        {
            Console.Clear();
            Console.WriteLine($"Préparation de {Name}...");
            for (int i = 0; i < ingredients.Length; i++)
             Console.WriteLine($"Utilisation de: {ingredients[i].Name}- x{ingredients[i].Qty}\n");
            
        }
    }
}
