using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic PNJ Camera Settings")]
public class PNJCameraSettingsBasic : PNJCameraSettings
{

    [SerializeField, Range(0, 1)] float targetPivotLocation = .5f;
    [SerializeField, Range(0, 360)] int angle = 45;
    [SerializeField, Range(0, 100)] int height = 2;
    [SerializeField] PNJCameraFollow cameraObject = null;

    public float TargetPivotLocation => targetPivotLocation;
    public int Angle => angle;
    public int Height => height;
    public PNJCameraFollow CameraObject => cameraObject;
}