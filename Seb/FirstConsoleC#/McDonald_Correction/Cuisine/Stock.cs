using System;

namespace McDonald_Correction
{
    internal class Stock
    {

        public Ingredient[] StockIngredients { get; private set; } = null;
        
      public  Stock(Ingredient[] _stock)
        {
            StockIngredients = _stock;
        }
        public bool CheckIngredient()
        {
            for (int i = 0; i < StockIngredients.Length;)
                if (0 == StockIngredients[i].Qty)
                    return false;

            return true;
        }
    }
}
