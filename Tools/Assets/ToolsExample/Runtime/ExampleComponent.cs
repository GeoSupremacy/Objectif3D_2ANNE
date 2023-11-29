using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleComponent : MonoBehaviour
{
    [SerializeField] int numberCubes = 2;
    [SerializeField] int gap = 2;
    [SerializeField] PrimitiveType type;
    List<GameObject> spawmItems = new();
    
    //void Start() =>SpawnCubes();


    
   public void SpawnCubes()
    {
        for (int i = 0; i < numberCubes * gap; i += gap)
        {
            Vector3 _position = transform.position + new Vector3(i, 0, 0);
            GameObject _item =GameObject.CreatePrimitive(type);
            _item.transform.position = _position;
            spawmItems.Add(_item);
        }
    }

   public void ClearItems()
    {
        for(int i = 0;i < spawmItems.Count;i++)
        {
            DestroyImmediate(spawmItems[i]);
        }
    }
}
