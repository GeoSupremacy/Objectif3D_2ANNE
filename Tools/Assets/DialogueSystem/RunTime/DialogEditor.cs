using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEditor
{
    List<int> l =new List<int>();
    public void Display()
    {
        for (int i = 0; i < l.Count; i++)
        {
            Debug.Log(l[i]);
        }
    }

    public void Add(int id)
    { 
        l.Add(id); 
    }
    public void Delete(int id)
    {
        if (!l.Contains(id))
            return;
        l.Remove(id);
    }
    public void Init()
    {
        l.Add(1);
        l.Add(2);
        l.Add(3);
    }
}
