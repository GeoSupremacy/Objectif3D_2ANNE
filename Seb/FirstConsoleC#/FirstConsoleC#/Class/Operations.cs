using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleC_.CalculatorSystem
{
    internal class Operations
    {
        public int Addition(int _a, int _b) => _a + _b;
        public int SubStract(int _a, int _b) => _a - _b;
        public int Divide(int _a, int _b) => _a / (_b == 0 ?1 : _b);
        public int Multiplication(int _a, int _b) => _a * _b;
    }
}
