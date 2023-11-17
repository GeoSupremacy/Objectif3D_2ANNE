using UnityEngine;

public abstract class SingletonPattern<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance = null;
    public static T Instance => instance;

    public virtual void Awake() => InitSingleton();

    void InitSingleton()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }
        instance = this as T;
    }
}
