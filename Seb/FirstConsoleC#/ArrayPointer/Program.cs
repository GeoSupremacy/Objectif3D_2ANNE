using System;

namespace ArrayPointer
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            Array<int> arr = new Array<int>();
            arr.AddNewElement(1);
            arr.AddNewElement(2);
            arr.AddNewElement(3);
            arr.Display();
            Console.ReadLine();
        }
    }
}
