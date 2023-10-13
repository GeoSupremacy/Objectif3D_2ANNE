using System;
using System.Runtime.Remoting.Lifetime;

namespace McDonald_Correction
{
    internal class PropertiesLesson
    {
        public event Action OnDie = null;
        string name = string.Empty;

        /// <summary>
        ///     
        /// </summary>
        //instance.name ="toto";
        public string Name
        {
            get { return name; }
            set {
                if (string.IsNullOrEmpty(value))
                    name = "Invalid Name";
                else
                    name = value;
            }

        }
        int age = 10;
        public int Age => age;
        int life = 100;
        public virtual int Life
        {
            get => life;
            set
            {
                life = value < 0 ? 0 : value > 100 ? 100 : value;
                if (life == 0)
                    Die();
            }
        }

        public int Mana { get; private set; } = 110;
        void Die() => Console.WriteLine("Dead");
    }

/*
public class Ex : PropertiesLesson 
{ 
        public override int Life { get => life; }
        public Ex() 
        { 

        }*/
}

