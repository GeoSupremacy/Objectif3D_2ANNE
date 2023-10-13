using System;

namespace McDonald_Correction
{
    internal class Menu
    {
        public event Action OnShowMenu = null;
        public event Action<int> OnSelection = null;

        string title = string.Empty;
        protected MenuData[] data = null;
        Stock restStock = null;
        Recette[] recipeList = null;
       public Menu(string _title, MenuData[] _data, Stock stock, Recette[] _recipe)
        {
           title = $"***{_title}****\n";
           data = _data;
            restStock = stock;
            OnShowMenu += Selection;
            recipeList = _recipe;
        }

        public virtual void ShowMenu() 
        { 
            Console.WriteLine(title);
            for (int i = 0; i < data.Length; i++)  
            {
                  for (int j = 0; j < restStock.StockIngredients.Length; j++) //Liste D'ingredient dans  Stock 
                  {
                        for (int L = 0; L < recipeList.Length; L++)// Liste de recette
                            for (int k = 0; k < recipeList[L].ingredients.Length; k++) //QTy pour une recette
                            {
                                int _QuantitePourRectte = recipeList[L].ingredients[k].Qty;
                                int _nombreDingredient = restStock.StockIngredients[j].Qty;

                             if (_nombreDingredient < _QuantitePourRectte) 
                                Console.WriteLine($" Recipe: {i + 1}--{data[i].Label} Rupture de stock"); 
                            else
                                Console.WriteLine($" Recipe: {i + 1}--{data[i].Label}");
                            
                        }

                }
                
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
