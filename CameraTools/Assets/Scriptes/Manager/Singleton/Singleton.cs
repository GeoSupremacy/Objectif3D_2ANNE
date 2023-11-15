using UnityEngine;

//Factory
public abstract class Singleton<T> : MonoBehaviour where T :MonoBehaviour
{
    static T instance = null;
    public static T Instance => instance;

    public virtual void Awake()
    {
        InitSingleton();
    }
    void  InitSingleton()
    {
        if (instance)
        {
            Destroy(this); //Il est unique et ne prend qu'une place, en tant qu'object
            return;
        }

        instance = this as T; 

    }
}
