using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Camera orbit settings")]
public class CameraOrbitSettings : CameraSettings
{
    [SerializeField, Header("Orbit settings"), Range(.1f, 10)]
    float radius = 4.77f;

    [SerializeField] AnimationCurve expression;

    public float Radius => radius;
    public AnimationCurve Expression => expression;
}
