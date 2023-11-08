
using UnityEngine;
using System;
using System.Collections;

public class Tweener 
{
    static public void StartToMove(MonoBehaviour _object, Vector3 _from, Vector3 _to, TweenEase _tweener, float _time = 1)
    {

        _object.StartCoroutine(MoveToCoroutine(_object.transform, _from,_to,_tweener,_time, null));

    }
    static public void StartToMoveCallback(MonoBehaviour _object, Vector3 _from, Vector3 _to, TweenEase _tweener, float _time = 1, Action _callback = null)
    {

        _object.StartCoroutine(MoveToCoroutine(_object.transform, _from, _to, _tweener, _time, _callback));

    }
    static IEnumerator MoveToCoroutine(Transform _transform, Vector3 _from, Vector3 _to, TweenEase _tweener, float _duration = 1, Action _callback = null)
    {
        float _time = 0;
        float _progess = 0;
        while (_time <= _duration)
        {
            _time += Time.deltaTime;
            _progess = _time / _duration;
            _transform.position= Vector3.Lerp(_from, _to, TweenerLibraryCorrection.GetTweenAlphaTweenEase(_tweener, _progess));
            yield return null;
        }
        _callback?.Invoke();
    }
}
