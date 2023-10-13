using System;

namespace McDonald_Correction
{
    internal class Recette
    {
        public string Name { get; private set; } = string.Empty;
        public Ingredient[] ingredients { get; private set; }

        public Recette( string _name, Ingredient[] _ingredients) 
        {
            Name = _name;
            ingredients =_ingredients;

        }

    }
}
