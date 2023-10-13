using System;
using System.Timers;

namespace McDonald
{
    internal class TimerCommande
    {
        Timer _timer = null;


        float currentTime = 0.0f;
        static int current = 0;
        public TimerCommande(float _setTime, string name)
        {
            current++;
            Timer _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Start();
            _timer.Elapsed += (o, e) =>
            {
                currentTime++;
                Console.WriteLine($"Time for: {name} {currentTime}");
                if (IsEnding(_setTime))
                {
                    Console.WriteLine($"Timer Stop");
                    _timer.Stop();
                }
            };
            
        }
         ~TimerCommande()
        {
            current = 0;
        }
        private void _t_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
      private bool IsEnding(float timeEnd) 
        {
            return currentTime== timeEnd;
         
        }
       // public static int GetCurrent() {  return current; }
    }
}
