
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrid : MonoBehaviour
{
    

    [SerializeField]
    Managed managed = null;
    [SerializeField]
    GameObject position;
    [field: SerializeField, Range(0, 100)]
    public float RangeColumn { get; private set; } = 5;
    [field: SerializeField, Range(0, 100)]
    public float RangRown { get; private set; } = 5;
    [field: SerializeField]
        public int Column { get; private set; } = 5;
    [field: SerializeField]
    public int Row { get; private set; } = 5;

    void Start()
    {
        Spawn();
    
    }
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        DrawDebug();
    }

    private void OnDestroy()
    {
       
    }

    void Spawn()
    {
        for (int i = 0; i < Column; i++)
            for (int j = 0; j < Row; j++)
                Define(i, j);


            
    }
    void Define(int i, int j)
    {
       
        Managed _mt = Instantiate(managed);
        _mt.transform.position = new Vector3(i * RangeColumn, 0, j * RangRown) + position.transform.position;
        _mt.MyCreator(this.GetComponent<Manager>());
        gameObject.GetComponent<Manager>().StartCoroutine(gameObject.GetComponent<Manager>().SetSister(_mt));
        gameObject.GetComponent<Manager>().Register(_mt);
    }
    void DrawDebug()
    {
        if (!position)
            return;
        for (int i = 0; i < Column; i++)
            for (int j = 0; j < Row; j++)
            {
                Vector3 _transform;

                _transform = new Vector3(i*RangeColumn, 0,j*RangRown) + position.transform.position;
                Gizmos.DrawSphere(_transform, 0.5f);
            }

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, position.transform.position);
        Gizmos.color = Color.white;
    }
}
