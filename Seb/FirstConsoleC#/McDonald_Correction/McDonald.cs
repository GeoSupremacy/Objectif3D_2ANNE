using System;

namespace McDonald_Correction
{
    internal class McDonald
    {
        Recette[] recipes = null;
        McdoMenu menu = null;
        public McDonald()
        {
            InitRecipes();
            InitMenu();
        }
        void InitRecipes()
        {
            recipes =new Recette[]
            {
                new Recette("frite", new Ingredient[]
                    {
                        new Ingredient("frite"),
                    }),

              new Recette("Burger", new Ingredient[]
                    {
                        new Ingredient("Pain"),
                    }),
             };

        }
        void InitMenu() 
        {
            for (int i = 0; i < recipes.Length; i++)
            { 
                //New McData
            }
            menu = new McdoMenu("McDonald", null);
            menu.ShowMenu();
        }
    }
}
