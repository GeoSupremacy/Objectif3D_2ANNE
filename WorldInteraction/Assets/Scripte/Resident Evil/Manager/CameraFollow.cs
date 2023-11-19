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
    [SerializeField, Category("Camera")]
    bool isFixe = false;
    [SerializeField, Category("Camera")]
    bool isEnable = false;
    bool isTargetModeDefine = true;
    [SerializeField, Category("Camera")]
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


    public void Target(Transform _target) => target = _target;

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

    public void Enabled() => cameraView.enabled = true;
    public void Disabled()=> cameraView.enabled = false;
   private void Start() => Init();

    private void LateUpdate()
    {
        UpdateCameraView(isTargetModeDefine);
        UpdateCameraPosition();
    }
    

    private void UpdateCameraView(bool _isMode)
    {
      
        if (!_isMode)
        {
            Debug.LogWarning("LOOk");
            cameraView.transform.LookAt(target);
        }
        
    }
    private void UpdateCameraPosition() { if (isFixe) cameraView.transform.position = transform.position; }
    
    private void Init()
    {

        cameraView= Instantiate(cameraView, transform.position, transform.rotation) ;
        if (!cameraView)
            throw new System.NullReferenceException("CameraFollow => Mising camera");
       
        cameraView.enabled = isEnable? true : false;

     
    }
    private void OnDestroy() =>Destroy(cameraView);
    
}
