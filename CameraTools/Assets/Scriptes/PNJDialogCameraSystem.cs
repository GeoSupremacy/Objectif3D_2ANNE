using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PNJDialogCameraSystem : MonoBehaviour
{
   

    #region settings
    [SerializeField] Transform target = null;

    [SerializeField] PNJCameraSettings settings;

    PNJCameraFollow cameraActive = null;

    #endregion

    #region fp
    bool isPNg = false;
    bool isPlayer = false;
    #endregion

    #region properties
    public Transform Target => target;
    public float DistanceToTarget => Vector3.Distance(CurrentPNJLocation, CurrentTargetPosition);
    public float Radius => DistanceToTarget / 2;
    public Vector3 CurrentPNJLocation => transform.position;
    public Vector3 CurrentTargetPosition
    {
        get
        {
            if (!target)
                throw new System.NullReferenceException("PNJDialogCameraSystem : Target is missing");
            return target.position;
        }
    }
    public Vector3 TargetPivot => Vector3.Lerp(CurrentPNJLocation, CurrentTargetPosition, CastSettings<PNJCameraSettingsBasic>(settings).TargetPivotLocation);
    public Vector3 TargetPNG => Vector3.Lerp(CurrentPNJLocation, transform.position, CastSettings<PNJCameraSettingsBasic>(settings).TargetPivotLocation);
    public Vector3 TargetPlayer=> Vector3.Lerp(CurrentPNJLocation, target.position, CastSettings<PNJCameraSettingsBasic>(settings).TargetPivotLocation);
    public Vector3 Height => Vector3.up * CastSettings<PNJCameraSettingsBasic>(settings).Height;
    public Vector3 FinalCameraLocation => GetCameraPosition(CastSettings<PNJCameraSettingsBasic>(settings).Angle, Radius) + Height;
    public Vector3 FinalCameraLocationWithoutHeight => GetCameraPosition(CastSettings<PNJCameraSettingsBasic>(settings).Angle, Radius);
    #endregion

    #region methods
    T CastSettings<T>(PNJCameraSettings _settings) where T : PNJCameraSettings => (T)_settings;
    public void SetTarget(Transform _target) => target = _target;
    public void InitCameraDialog()=> cameraActive = Instantiate(CastSettings<PNJCameraSettingsBasic>(settings).CameraObject, FinalCameraLocation, Quaternion.identity);
    
    public Vector3 GetCameraPosition(float _angle = 45, float _radius = 10)
    {
        float _rad = _angle * Mathf.Deg2Rad;
        return TargetPivot + new Vector3(Mathf.Cos(_rad) * _radius, 0, Mathf.Sin(_rad) * _radius);

    }
    private void Awake()
    {

        ManagerUI.OnLookPNJ += SetLookPNG;
        ManagerUI.OnLookPlayer += SetLookPlayer;
    }
  
    void SetLookPNG()
    {
        isPNg = true;
        isPlayer = false;
    }
    void SetLookPlayer()
    {
        isPNg = false;
        isPlayer = true;
    }
    private void UpdateCamera()
    {
        if (!cameraActive)
            throw new System.NullReferenceException("PNJDialogCameraSystem =>UpdateCameraLocation(): missing camera");
        cameraActive.SetDestination(FinalCameraLocation);

        if(isPNg)
            cameraActive.SetLookAt(TargetPNG);
        else if (isPlayer)
            cameraActive.SetLookAt(TargetPNG);
        else
            cameraActive.SetLookAt(TargetPivot);
    }
    private void Update() => UpdateCamera();

    private void OnDrawGizmos()
    {
        Gizmos.color = target ? Color.green : Color.red;
        Gizmos.DrawSphere(target ? CurrentTargetPosition + Vector3.up * 2 : Vector3.zero, .2f);
        if (!target)
            return;
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(CurrentTargetPosition, CurrentPNJLocation);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(TargetPivot, .3f);
        //Gizmos.DrawWireSphere(TargetPivot, DistanceToTarget / 2);
        GizmoUtils.DrawCircle(TargetPivot, Radius, Color.green, 15);
        Gizmos.DrawSphere(FinalCameraLocation, .2f);
        Gizmos.DrawLine(FinalCameraLocation, TargetPivot);
        Gizmos.DrawLine(FinalCameraLocationWithoutHeight, TargetPivot);
        Gizmos.DrawLine(FinalCameraLocation, FinalCameraLocationWithoutHeight);
    }
    #endregion
}