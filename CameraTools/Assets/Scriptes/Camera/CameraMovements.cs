using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.SceneView;

public enum MovementType
{
    Lerp,
    ConstantLerp
}
public enum OffsetType
{
    World,
    Local
}

[RequireComponent(typeof(CameraManaged))]
public abstract class CameraMovements : MonoBehaviour
{

    [SerializeField]
    protected Transform target = null;

    #region settings
    [SerializeField, Header("Scriptable asset")]
    protected CameraSettings cameraSettings = null;
    #endregion

    #region Debug
    [SerializeField, Header("Debug")]
    protected bool useDebug = true;
    [SerializeField]
    protected Color validDebugColor = Color.green,
                           noValidDebugColor = Color.red;

    #endregion

    #region Properties

    public bool IsValid => target;

    public Vector3 CurrentPosition => transform.position;
    public virtual Vector3 TargetPosition
    {
        get
        {
            if (!target)
                throw new System.NullReferenceException("target is missing");
            return target.position;

        }
    }
    public virtual Vector3 FinalPosition
    {
        get
        {
            return TargetPosition + Offset;
        }
    }

    public virtual Vector3 Offset
    {
        get { return Vector3.zero; }

    }
    #endregion

    void LateUpdate()
    {
        UpdateCameraPosition();
        UpdateLookAtCamera();
    }
    public void SetTarget(Transform _target) => target = _target;

    protected virtual void UpdateCameraPosition() { }

    protected virtual void UpdateLookAtCamera()
    {
        Vector3 _fwd = (TargetPosition - transform.position).normalized;
        Vector3 _right = Vector3.Cross(Vector3.up, _fwd).normalized;
        Vector3 _up = Vector3.Cross(_fwd, _right);
        Matrix4x4 _matrix = new Matrix4x4(_right, _up, _fwd, new Vector4(0, 0, 0, 1));
        transform.rotation = _matrix.rotation;
    }
    private void OnDrawGizmos()=> DrawDebugMovement();
    protected virtual void DrawDebugMovement() { }
    protected Vector3 GetLocalOffset(float _x, float _y, float _z)
    {
        return target.right * _x +
               target.up * _y +
               target.forward * _z;
    }

    protected TCamSettings CastSettings<TCamSettings>() where TCamSettings : CameraSettings
    {
        return (TCamSettings)cameraSettings; // on peut renommer T en TCamSettings ici mais il faut commencer par un T
    }
}