using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

[Serializable]
public class MySpawnerDictionary<TKey, TValue>
{
    [SerializeField] List<MySpawnKeyValuePair<TKey, TValue>> pair = new();
    public void Add(TKey _key, TValue _value)
    {
        if (ContainsKey(_key))
            return;
        pair.Add(new MySpawnKeyValuePair<TKey, TValue>() {Key = _key, Value = _value });
    }
   public  bool ContainsKey(TKey _key)
    {
        for (int i = 0; i < pair.Count; i++)
        {
            if (pair[i].Key.Equals(_key))
                return true;
        }
        return false;
    }
    public TValue Get(TKey _key)
    {
        for (int i = 0; i < pair.Count; i++)
        {
            if (pair[i].Key.Equals(_key))
                return pair[i].Value;
        }
        return default;
    }
}

public struct MySpawnKeyValuePair<TKey, TValue>
{
    [SerializeField] TKey key;
    [SerializeField] TValue _value;

    public TKey Key { get => key; set => key = value; }
    public TValue Value { get => _value; set => _value = value; }
}