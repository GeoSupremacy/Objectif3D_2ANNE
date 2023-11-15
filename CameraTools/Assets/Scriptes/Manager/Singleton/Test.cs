using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SingletonExample.Instance.SayHello();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
