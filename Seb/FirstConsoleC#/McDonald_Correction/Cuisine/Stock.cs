using System;



namespace McDonald_Correction
{
    internal class Stock
    {
        public Action OnReduceStock = null, OnRefillStock = null;
       public Ingredient[] StockIngredients { get;  set; } = null;
        /// <summary>
        /// {
        /// New Ingredient
        /// }
        /// </summary>
        /// ></param>
      public  Stock(Ingredient[] _stock)
        {
            StockIngredients = _stock;
        }
        public bool CanUsSotck(Ingredient _ing)
        {
            for (int i = 0; i < StockIngredients.Length; i++)
            {
                if (StockIngredients[i].Name.ToLower() == _ing.Name.ToLower())
                    return StockIngredients[i].Qty < _ing.Qty;
            }
               return false;
        }
            public bool CheckIngredient(Recette[] _recipeList/* Ingredient _ing*/)
        {
            


            for (int j = 0; j < _recipeList.Length; j++)
                for (int L = 0; L < _recipeList[j].ingredients.Length; L++)
                    for (int i = 0; i < StockIngredients.Length; i++)
                    {
                        int Qtyfor = _recipeList[j].ingredients[L].Qty;
                        int restQt = StockIngredients[i].Qty;

                        string nameIgdStock = StockIngredients[i].Name;
                        string nameIgdRecp = _recipeList[j].ingredients[L].Name;
                        if (nameIgdStock== nameIgdRecp)
                                return restQt < Qtyfor;
                    }
            return true;
        } 
      public void RefillStock(/* Data Stock*/)
      {
            //Data Stock
            //OnRefillStock.Invoke( );
      }
      public void ReduceStock(Ingredient _ing) 
        {
            for (int i = 0; i < StockIngredients.Length; i++)
            {
                if (StockIngredients[i].Name.ToLower() == _ing.Name.ToLower())
                {
                    if (StockIngredients[i].Qty <= 0) StockIngredients[i].Qty = 0; else StockIngredients[i].Qty = _ing.Qty;
                 }
            }
            //OnReduceStock.Invoke();
        }
        public void ShowStock()
        {
            for(int i = 0; i<StockIngredients.Length; i++)
            {
                Console.WriteLine($"{StockIngredients[i].Name}- x{StockIngredients[i].Qty}");
            }
        }
    }
}
