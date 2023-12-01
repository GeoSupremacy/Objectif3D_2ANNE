using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

        
public class ExampleComponent : MonoBehaviour
{
    [SerializeField] private int numberCubes = 2; 
    
    [SerializeField] int gap = 2;
   
    [SerializeField] PrimitiveType type;
    [SerializeField, HideInInspector] List<GameObject> spawmItems = new();
    [SerializeField] Data info = new();


    public bool ISValid() => numberCubes > 0;

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
        spawmItems.Clear();
    }

    [Serializable]
    public class Data
    {
        int value = 200;
    }
}//

