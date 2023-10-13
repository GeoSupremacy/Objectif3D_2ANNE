using System;

using FirstConsoleC_.CalculatorSystem;
namespace FirstConsoleC_
{
    
    internal class Program
    {
         
       //new Calculator() == new() en fonction du framework
        static void Main(string[] args)
        {
            new LambdaExpression();
            //Calculator _cal = new Calculator();
            //ActionLesson _al = new ActionLesson(); ;
            // Menu _c = new Menu();
            // DelegatesLessons _b=  new DelegatesLessons();
            // _b.Execute(_c);
            // !!!! new Calculator();//On peut lancer dans le constructor  Calculator _calculator = new Calculator() == new Calculator()

            /*  ActionLesson _a= new ActionLesson();
              _a.onAction = null;
              EventLesson.OnMyEvent += null;*/
            Console.Read();
        }
    }
}
