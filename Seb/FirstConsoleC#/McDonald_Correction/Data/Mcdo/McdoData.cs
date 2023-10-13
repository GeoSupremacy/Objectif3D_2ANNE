using McDonald_Correction;
using System;

namespace McDonald_Correction
{
    internal class McdoData : MenuData
    {

        public Recette Recipe { get; private set; } = null;
        public Stock Stock { get; set; } = null;
        public McdoData(string _label, Action _menuAction, Recette recette) : base(_label, _menuAction)  
        {
            Recipe = recette;
        }
    }
}
