using UnityEngine;

public class SingletonExample : Singleton<SingletonExample>
{

   
    public void SayHello() => Debug.Log("Hello");
}
