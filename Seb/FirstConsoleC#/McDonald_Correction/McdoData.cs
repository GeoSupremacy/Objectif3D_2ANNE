using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonald_Correction
{
    internal class McdoData : MenuData
    {
        Recette recipe = null;
        public McdoData(string _label, Action _menuAction, Recette _recipe) : base(_label, _menuAction)  
        {

        }
    }
}
