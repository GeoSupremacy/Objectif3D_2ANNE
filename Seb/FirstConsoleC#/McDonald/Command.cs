using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace McDonald
{
    #region Recette
    struct Ingredient
    {
        string name;
        int number;
        public int IngredientNumber() { return number; }
       public Ingredient(string _name, int _number) { name = _name; number = _number; }
        public void SetNumber(int _number) { number = _number; }
    }
    internal class Recette
    {  
        string name; 
        float timeToPrepare;
        Ingredient[] ingredients = null;
        public Recette(string _name, float _timetoPrepare, Ingredient[] _ingredient) { name = _name; timeToPrepare = _timetoPrepare; ingredients = _ingredient; }
        public float Preparation() { return timeToPrepare; }
        public string Name() {  { return name; } }
    }
    #endregion Recette
    internal class Command
    {
        public  Action<float, string> ActiveTimer = null;
        Recette[] commande = null;
        Ingredient[] listFite, listBurgerKing = null;
        #region constructeur/destructeur
        public Command()
        {
            //Frite
            listFite = new Ingredient[]
            {
                new Ingredient("Patate",10),
             };
            listBurgerKing = new Ingredient[]
            {
                new Ingredient("Salade",10),
                new Ingredient("Patate",10),
                new Ingredient("Salade",10),
             };
            commande = new Recette[]
            {
                    new Recette("Burger King",5,listBurgerKing),
                    new Recette("Burger Vegan",5,listBurgerKing),
                    new Recette("Frites ",5,listFite),
                    
            };   
            

        }
        #endregion
        #region Acesseur
        //Que le menu est accès au commande est timer
        public Recette[] GetCommande() { return commande; }
        
        #endregion 
     
    }
}
