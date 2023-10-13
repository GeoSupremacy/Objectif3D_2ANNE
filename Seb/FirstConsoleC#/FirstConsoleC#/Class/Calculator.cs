using System;


using FirstConsoleC_.CalculatorSystem;

namespace FirstConsoleC_
{
    internal class Calculator
    {
        Menu mainMenu = null;
        public Calculator()
        {
            Operations operations = new Operations();
            string[] _function = 
            { 
                "Addition",
                "Substract",
                "Divide",
                "Multiply" 
            };
           Action[] _test =
            {
               () => Console.WriteLine(operations.Addition(2,5)),
               () => Console.WriteLine(operations.SubStract(2,5)),
               () => Console.WriteLine(operations.Divide(2,5)),
               () => Console.WriteLine(operations.Multiplication(2,5)),
                
        };
            Func <int, int, int>[] _calculatorFunc =
            {
                operations.Addition,
                operations.SubStract,
                operations.Divide,
                operations.Multiplication,
        };

            mainMenu = new Menu("Calculator", _function, _test); 

        }
        
    }
}
