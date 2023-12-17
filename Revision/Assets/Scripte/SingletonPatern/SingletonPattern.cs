using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPattern<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    static T Instance =>instance;
    private void Awake() => InstanceSingleton();
    void InstanceSingleton()
    {
        if(instance)
        { 
            Destroy(instance);
            return; 
        }
            
      
         instance = this as T;
    }

}
