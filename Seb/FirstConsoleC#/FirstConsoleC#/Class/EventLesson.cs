using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleC_
{
    internal class EventLesson
    {
        public static event Action OnMyEvent = null;
        public void Execute()
        {
            OnMyEvent.Invoke();
        }
    }
}
