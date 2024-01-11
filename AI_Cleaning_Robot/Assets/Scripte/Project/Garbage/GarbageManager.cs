using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class GarbageManager : MonoBehaviour
{
    public static Action OnDeaths = null;
   [SerializeField]
   List<Garbage> allGarbageInScence = new List<Garbage>();
    [SerializeField]
    float waitForSecond = 5;
    private void Awake()
    {
        Garbage.onRegister += Register;
        Garbage.onDeath += Remove;
    }
    void Register(Garbage _garbage) =>allGarbageInScence.Add(_garbage);
    void Remove(Garbage _garbage)
    {

        allGarbageInScence.Remove(_garbage);
    }

    IEnumerator CheckList()
    {
        yield return new WaitForSeconds(waitForSecond);
        if(allGarbageInScence.Count ==0)
            OnDeaths?.Invoke();
        else
            StartCoroutine(CheckList());
    }
    private void Start() =>StartCoroutine(CheckList());
    private void OnDestroy()
    {
        OnDeaths = null;
    }
}
