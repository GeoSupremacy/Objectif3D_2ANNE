using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace FirstConsoleC_
{
    internal class DelegatesLessons
    {
        public delegate int OnDelegates();
        public delegate void OnDelegate();
        delegate void OnDelegate_Int(int _value);
        OnDelegate onDelegate;
        OnDelegate_Int onDelegate_Int;
        public DelegatesLessons()
        {

            onDelegate += Test;//Bind
            //onDelegate += Test;
            onDelegate();//Invoke
            //onDelegate -= Test; //Supp un abonnement
            //onDelegate();
            //onDelegate = null; //Suppr tous les abonndement
            //onDelegate_Int += Test;
            //onDelegate_Int(10);
            //onDelegate Erreur compilateur
        }
         void Test()
        {
            Console.WriteLine("Test");
            Execute(CallBack);
        }
        void CallBack() //Rappel à la fin de l'appel d'évent  //ex Login callBack affiche un menu
        {
            Console.WriteLine("CallBack");
        }
       void Test(int _value)
        {
            Console.WriteLine(_value);

        }
       public void Execute(OnDelegate _method)
        {
            //Timer _t = new Timer(); Voir plus tard
            //_t.Interval = 1000;
           // _Thread.Elapsed += _method
            _method();
        }
        //define un delegate -> type(ex void)->void
        //typedef 
    }
}
