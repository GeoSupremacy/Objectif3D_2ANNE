using UnityEngine;
using System;
using UnityEditor;

public enum TweenEase
{
    EaseInSine, EaseInOutQuint, EaseInOutBounce, EaseOutBounce, EaseInBounce,
}

public class TweenerLibraryCorrection
{

  

    public static float GetTweenAlphaTweenEase(TweenEase _erase, float _progress)
    {
        switch (_erase)
        {
            case TweenEase.EaseInSine:
                return EaseInSine(_progress);
            case TweenEase.EaseInOutQuint:
                return EaseInOutQuint(_progress);
            case TweenEase.EaseInOutBounce:
                return EaseInOutBounce(_progress);
            case TweenEase.EaseOutBounce:
                return EaseOutBounce(_progress);
            case TweenEase.EaseInBounce:
                return EaseInBounce(_progress);
            default:
                return 0;
        }
    }

    public static float EaseInSine(float _prog) => 1 - Mathf.Cos((_prog * Mathf.PI) / 2);
    public static float EaseInOutQuint(float _prog) => _prog < 0.5 ? 16 * _prog * _prog * _prog * _prog * _prog : 1 - Mathf.Pow(-2 * _prog + 2, 5) / 2;
    public static float EaseInOutBounce(float _prog) => _prog < 0.5 ? (1 - EaseOutBounce(1 - 2 * _prog)) / 2: (1 + EaseOutBounce(2 * _prog - 1)) / 2;
    public static float EaseOutBounce(float _progress)
    {
        float _n1 = 7.5625f;
        float _d1 = 2.75f;

        if (_progress < 1.0f / _d1) return _n1 * _progress * _progress;
        
        else if (_progress < 2.0f / _d1) return _n1 * (_progress -= 1.5f / _d1) * _progress + 0.75f;
        
        else if (_progress < 2.5f / _d1) return _n1 * (_progress -= 2.25f / _d1) * _progress + 0.9375f;
        
        else return _n1 * (_progress -= 2.625f / _d1) * _progress + 0.984375f;
        
    }
    public static float EaseInBounce(float _progress) => _progress - EaseOutBounce(1 - _progress);
}
