using System;

namespace McDonald_Correction
{
    internal class McdoMenu :Menu
    {
        public McdoMenu(string _title, MenuData[] _data, Stock stock, Recette[] _recipe) : base (_title, _data, stock, _recipe) 
        {
            OnSelection += (index) =>
            {
                data[index]?.MenuAction?.Invoke();

               
            };
        }
        public override void ShowMenu()
        {
            base.ShowMenu();
        }
    }
}
