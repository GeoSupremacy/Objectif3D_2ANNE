﻿using System;

namespace McDonald_Correction
{
    internal class Ingredient
    {
        string name = string.Empty;
        int quantity = 1;

        public string Name { get; private set; } = string.Empty;
        public int Qty { get; private set; } = 1;
        public Ingredient(string _name, int _quantity=1) 
        {
            name = _name;
            quantity =_quantity;

        }
    }
}
