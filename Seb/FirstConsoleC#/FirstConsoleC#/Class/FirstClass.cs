using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleC_
{
    
    internal class FirstClass
    {
     #region f/p
        private int numberOne = 0;
        private int numberTwo = 0;
     #endregion f/p
     #region Constructeur/destructeur
        public FirstClass() { numberOne= numberTwo = 1; }
        public FirstClass(int _numberOne, int _numberTwo) { numberTwo = _numberOne; numberTwo = _numberTwo; }
     #endregion Constructeur/destructeur
     #region Method
        public void Test() { Console.WriteLine(numberOne); Console.WriteLine(numberTwo); }
        public int Compare(int _from, int _to)
        {
            if (_from > _to)
                return _from;
            return _to;
        }
        #endregion Method
        #region Acesseur
        public int GetNumberOne() { return numberOne; }
        public int GetNumberTwo() { return numberTwo; }
        public void SetNumberOne(int _number) { numberOne = _number; }
        public void SetNumberTwo(int _numberOne) { numberTwo = _numberOne; }
        #endregion Acesseur
        #region operator

        #endregion operator

    }
}
