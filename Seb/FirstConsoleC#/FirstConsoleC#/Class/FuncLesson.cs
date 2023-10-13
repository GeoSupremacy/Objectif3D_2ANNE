using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleC_
{
    //Type retour obligé
    internal class FuncLesson
    {
        Func<int> onFuncInt = null;
        Func<int, int ,int> onFuncIntParams = null;
        public FuncLesson()
        {
           // onFuncInt += Test;
            onFuncIntParams += TestParam;
            Console.WriteLine(onFuncIntParams?.Invoke(2,5));
            Console.WriteLine(Value(null) ==null);
            // Console.WriteLine(onFuncInt ?.Invoke());
        }

        int Test() => 2;
        int TestParam(int _a, int _b) => _a+_b;
        int Value(Func<int, int> _ex) => _ex.Invoke(2);
    }
}
