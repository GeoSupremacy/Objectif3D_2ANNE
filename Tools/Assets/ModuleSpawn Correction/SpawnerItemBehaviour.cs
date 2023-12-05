using System;
using UnityEngine;

using Random = UnityEngine.Random;
[Serializable]
public class SpawnerItemBehaviour
{
    [SerializeField] GameObject item = null;
    [SerializeField] GameObject[] items = null;
    [SerializeField] bool useSingleItem = true;

    public GameObject PickItem()
    {
        return  useSingleItem ? item : GetRandomObject();
    }
    public GameObject GetRandomObject()
    {
        int _rand = Random.Range(0, items.Length);
        return items[_rand];
    }

    public Vector3 GetItemPosition(Vector3 _from)
    {
        bool _hit = Physics.Raycast(_from, _from - new Vector3(0, -1, 0), out RaycastHit _result, 100);
        Debug.DrawRay(_from, new Vector3(0, -1, 0) * 100, Color.red, 2);
        return _hit ? _result.point : _from;
    }
}
