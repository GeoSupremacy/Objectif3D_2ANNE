using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Scriptes toSpawn = null;
    Scriptes clone = null;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        if(!toSpawn) return;
       clone = Instantiate(toSpawn);
        Debug.Log("Hi");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
