using System;
using System.Timers;


namespace McDonald_Correction
{
    internal class McDonald
    {
        Timer timer = new Timer();
        TimeSpan timerKitchen = new TimeSpan();
        Recette currentRecipe = null;
        Recette[] recipes = null;
        McdoMenu menu = null;
        public McDonald()
        {
            InitRecipes();
            InitTimer();
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
                        new Ingredient("Salade"),
                        new Ingredient("Steaak"),
                    }),
             };

        }
        void InitMenu() 
        {
            McdoData[] _data = new McdoData[recipes.Length];
            for (int i = 0; i < recipes.Length; i++)
            { 
                Recette _r = recipes[i];
                int _index = i;
                _data[_index] = new McdoData(_r?.Name, () => MakeRecipe(_index), _r); 
            }
                

            menu = new McdoMenu("McDonald", _data);
            menu.ShowMenu();
        }
        void MakeRecipe(int _index)
        {
            timerKitchen = new TimeSpan();
            timer.Start();
            currentRecipe = recipes[_index];
            recipes[_index].Prepare();
        }
       void InitTimer()
        {
            timer.Interval = 1000;
            timer.Elapsed += (e, o) =>
                {
                    timerKitchen += TimeSpan.FromSeconds(1);
                    if (timerKitchen == currentRecipe?.MinuteTimer)
                    {
                        timer.Stop();
                        Console.Clear();
                        menu.ShowMenu();
                    }
                    else
                    { 
                        Console.Clear();
                        Console.WriteLine($"Preparation de {currentRecipe.Name}->{timerKitchen}/{currentRecipe?.MinuteTimer}"); 
                    }
                    
            };
        }
    }
}
