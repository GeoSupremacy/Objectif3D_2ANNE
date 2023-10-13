using System;
using System.Timers;
namespace FirstConsoleC_
{
    internal class LambdaExpression
    {
        Action<int> first = (x) => Console.WriteLine($"R = {x}");
        Action<bool, int> compute = (b, i) => Console.WriteLine($"S = {(b ? (i-2) : i)}");
        Func<int, int ,int> last = (x, y) => x* y;
       public LambdaExpression()
        {
            Timer _t = new Timer();
            _t.Interval = 1000;
            _t.Start();
            int x = 0;
            _t.Elapsed += (o, e) =>
            {
                x++;
                Console.WriteLine($"toto{o}-{x}");
            };
            first?.Invoke(2);
            first?.Invoke(20);
            compute(true, 2);
            compute(false, 20);
            Console.WriteLine(last?.Invoke(2, 2));
            Loading(() => Console.WriteLine("Loaded !"));
        }

        private void _t_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
        
        void Loading(Action _result)
        {
            _result?.Invoke();
        }
    }
}
