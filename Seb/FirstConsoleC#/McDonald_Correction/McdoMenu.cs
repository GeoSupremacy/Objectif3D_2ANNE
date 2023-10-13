using System;

namespace McDonald_Correction
{
    internal class McdoMenu :Menu
    {
        public McdoMenu(string _title, McdoData[] _data): base (_title, _data) 
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
