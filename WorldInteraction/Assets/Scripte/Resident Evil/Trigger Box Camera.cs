using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetMode
{
    Target,
    Define,
}


public class TriggerBoxCamera : MonoBehaviour
{
    #region P
    #region Settings
    [SerializeField] 
        private Transform target;
    [SerializeField]
        private TargetMode targetMode;
    [SerializeField]
    private CameraFollow cameraFollow;
    #endregion
    bool isTrigger = false;
    #endregion


    public Vector3 CameraFollowPosition 
    { get 
        {
            if (!cameraFollow)
                throw new System.NullReferenceException("TriggerBoxCamera =>mising Camera");
            return cameraFollow.transform.position;
        }
        private set { } }
    public Vector3 TargetPosition
    { 
        get
    {
            if (!target)
                throw new System.NullReferenceException("TriggerBoxCamera =>mising target");
            return target.transform.position;
        }
private set{ } } 
    public Vector3 PositionOffset => transform.position + CameraFollowPosition;
    public Vector3 Position => transform.position;

    #region Trigger
    private void Start()
    {
       
        cameraFollow.Position = PositionOffset;
        cameraFollow.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
        cameraFollow.Target(target);
        cameraFollow.SetModeTarget(targetMode);
        cameraFollow.Enabled();
    }
    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;
        cameraFollow.Disabled();
    }
    #endregion

    #region Gizmos
    private void OnDrawGizmos()
    {
        DrawBoxCollider();
        DrawCamera();
        DrawBoxView();
    }
    private void DrawCamera()
    {

        Vector3 _PositionCameraFollow = cameraFollow? CameraFollowPosition : Position;
        Gizmos.color = cameraFollow ? Color.green : Color.red;
        Gizmos.DrawWireCube(_PositionCameraFollow, new Vector3(1,1,1));
    }
    private void DrawBoxView()
    {
        Vector3 _lookAt = target ? TargetPosition : CameraFollowPosition + Vector3.forward * 2;


        if (targetMode == TargetMode.Define)
        {
            Gizmos.color = Color.magenta;
            _lookAt = CameraFollowPosition + Vector3.forward * 2;
        }

        else
            Gizmos.color = target ? Color.yellow : Color.red;
        
        Gizmos.DrawLine(CameraFollowPosition, _lookAt);
        Gizmos.DrawSphere(_lookAt, 0.1f);
    }
    private void DrawBoxCollider()
    {
        Vector3 _scale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Gizmos.color = isTrigger?Color.green: Color.yellow;
        Gizmos.DrawWireCube(transform.position, _scale);
    }
    #endregion
}
