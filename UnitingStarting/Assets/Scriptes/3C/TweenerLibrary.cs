using UnityEngine;
using System;


public enum  TweenerFunctions
{
    EaseInSine,
    
    




}
public class TweenerLibrary 
{

    static public void StartToMove(MonoBehaviour _object, Vector3 _from, Vector3 _to, TweenerFunctions _tweener, float _time, Action _action =null)
    {
        
        switch (_tweener)
        {
            case TweenerFunctions.EaseInSine:
                {
                    float _currentTime = 0;
                    while (_currentTime < _time)
                    {

                        _object.transform.position = Vector3.Lerp(_from, _to, EaseInSine(_currentTime));
                        _currentTime += Time.deltaTime;
                    }
                    break;
                }
            default:
            break;
        }
      
    }

  
    public static float EaseInSine(float _animation) => 1 - Mathf.Cos((_animation * Mathf.PI) / 2);
   
}
