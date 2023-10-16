using System;

namespace McDonald_Correction
{
    internal class Ingredient
    {
        //string name = string.Empty;
        //int quantity = 1;

        public string Name { get; private set; } = string.Empty;
        public int Qty { get;  set; } = 1;
        public string FullName => $"{Name}- x{Qty}"; /* ToString choose Format*/
        public Ingredient(string _name, int _quantity=1) 
        {
            Name = _name;
            Qty = _quantity;

        }
        public static Ingredient operator +(Ingredient _this, int _value) 
        {
            _this.Qty = _value;
            return _this;
        }
        public static bool operator ==(Ingredient _this, Ingredient _ing)
        {

            return _this.Name.ToLower() == _ing.Name.ToLower();
        }
        public static bool operator !=(Ingredient _this, Ingredient _ing)
        {
           
            return _this.Name.ToLower() != _ing.Name.ToLower();
        }
    }
}
