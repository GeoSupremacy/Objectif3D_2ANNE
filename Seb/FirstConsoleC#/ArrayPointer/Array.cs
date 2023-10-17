using System;

namespace ArrayPointer
{
    internal class Array<T>
    {
        T[] truc = new T[0];
        public int Count => truc.Length;
        
       // public int this[int _index] => truc[_index];
        public T this[int _index]
        {
            get { return truc[_index]; }
        }
        public Array() {  }

        public void AddNewElement(T value)
        {
           
            T[] _temp = truc;
          
            truc = new T[_temp.Length+1];

            for (int i = 0; i <= _temp.Length-1; i++)
                truc[i] =_temp[i];
            
            truc[_temp.Length] = value;
        }
        public void Remote(T _value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (truc[i].Equals(_value)) // truc[i] ==_value  ne marche que des types natif mais Equal peut vérifié le types de l'object
                { RemoveAt(i); return;}
                
            }
        }
        public void RemoveAt(int index)
        {
            if (truc == null)
             return;

            T[] _copy = truc;
            truc = new T[_copy.Length + 1];

            for (int i = 0;i < index; i++) 
                truc[i] = _copy[i];
            for (int i = index+1; i < _copy.Length; i++)
                truc[i-1] = _copy[i];
        }
        int Length() => truc.Length;
        public void Display() 
        {
            for (int i = 0; i < Length(); i++) { Console.WriteLine(truc[i]); }
        }
        public void Clear(){ truc = new T[0]; }

        //FUll MORGAN

        public static Array<T> operator +(Array<T> _this, T _value) 
        {
            _this.AddNewElement(_value);
            return _this;
        }
        public static bool operator ==(Array<T> _this, Array<T> _other)=> _this== _other;
        public static bool operator !=(Array<T> _this, Array<T> _other) => _this != _other;
        
      //  public static bool operator !=(T _this, T _other)=> _this != _other;
       // public static bool operator ==(T _this, T _other) => _this == _other;
    }
}
