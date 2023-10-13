using System;

namespace FirstConsoleC_
{
    //type déjà donner (void)
    internal class ActionLesson
    {
       public Action onAction = null;
        Action<int> onActionInt = null;
        public ActionLesson()
        {
            //onAction += Test; onAction attend un void sans paramètre
            onAction += () =>
            {
                IntTest(5);
            };
            onActionInt += (myInt) =>
            {
                TestCallBack();
            };
            onAction = () =>
            {
                for (int i = 0; i < 3; i++)
                    Test();

                // onAction += Test;
                // onAction += Test;
                // onAction += Test;
            };
            
            // onActionInt += IntTest;
            //onAction() soit Delegate soit rien
            onAction?.Invoke();
            onActionInt?.Invoke(2);//check Test si null  "?"=> ne faire l'execution si onAction n'est pas null
            //Execute(TestCallBack);
        }

        public void Test()
        {
            Console.WriteLine("Test action");
        }
        public void IntTest(int _a)
        {
            Console.WriteLine($" Init Test with lambda {_a}");
        }
        public void Execute(Action _callback)
        {
            _callback();
        }
        void TestCallBack()
        {
            Console.WriteLine("TestCallBack");
        }
    }
}
