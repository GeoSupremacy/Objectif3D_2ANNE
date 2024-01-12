using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class GarbageManager : MonoBehaviour
{
    public static Action OnDeaths = null;
    [SerializeField]
    List<Garbage> allGarbageInScene = new List<Garbage>();
    [SerializeField, Range(0,100)]
    float waitForSecond = 5;

    private void Awake()
    {
        Garbage.onRegister += Register;
        Garbage.onDeath += Remove;
    }
    private void Start()
    {
    
        StartCoroutine(CheckList());
    }


    private void OnDestroy()
    {
        OnDeaths = null;
    }

    void Register(Garbage _garbage) => allGarbageInScene.Add(_garbage);
    void Remove(Garbage _garbage)
    {

        allGarbageInScene.Remove(_garbage);
    }
    IEnumerator CheckList()
    {
        yield return new WaitForSeconds(waitForSecond);
        for (int i =0; i< allGarbageInScene.Count; i++)
            if (!allGarbageInScene[i])
                Remove(allGarbageInScene[i]);
        if (allGarbageInScene.Count == 0)
            OnDeaths?.Invoke();
        else
            StartCoroutine(CheckList());

    }
}
