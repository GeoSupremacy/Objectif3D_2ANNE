using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(ItemManaged))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField, Category("Camera")]
    private Camera cameraView = null;
    bool isTargetModeDefine = true;
    private Transform target;

    public Vector3  TargetPivot 
    { get
        {
            if (!target)
                throw new System.NullReferenceException("CameraFollow =>mising Target");
            return target.transform.position;
        }
       // private set;// { target.transform.position = value; }
    }
    public Vector3 Position { get;  set; }
    void Start() => Init();

    public void Enabled() => cameraView.enabled = true;
    public void Disabled()=> cameraView.enabled = false;
    private void LateUpdate()=> UpdateCameraView(isTargetModeDefine);
    
    public void Target(Transform _target)=>  target = _target;
    
    public void SetModeTarget(TargetMode _targetMode)
    {
        switch (_targetMode) 
        {
            case TargetMode.Target:
                {
                    isTargetModeDefine = false;
                    Debug.LogWarning("Target");
                    break;
                }
            case TargetMode.Define:
                {
                    isTargetModeDefine = true;
                    Debug.LogWarning("Define");
                    break;
                }
            default:
                break;
        }
    }

    private void UpdateCameraView(bool _isMode)
    {
      
        if (!_isMode)
        {
            Debug.LogWarning("LOOk");
            cameraView.transform.LookAt(target);
        }
        
    }

    private void Init()
    {

        cameraView= Instantiate(cameraView, transform.position, transform.rotation) ;
        if (!cameraView)
            throw new System.NullReferenceException("CameraFollow => Mising camera");

        cameraView.enabled = true;

     
    }
}
