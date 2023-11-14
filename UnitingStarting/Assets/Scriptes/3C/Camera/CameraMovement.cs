using System;
using UnityEngine;


[Serializable]
public struct Settings
{
    #region settings
    
   public enum MovementType
    {
        Lerp,
        ConstantLerp,
    }

   public enum OffsetType
    {
        World,
        Local,
    }

    [SerializeField, Header("Camera settings"), Range(-20, 20)]
    MovementType movementType;
    [SerializeField]
    OffsetType offsetType;
    [SerializeField]
    float offsetX, offsetY, offsetZ;
   



    [SerializeField, Range(0, 10)]
    float speed;

    public float Speed => speed;
    public float OffsetX => offsetX;
    public float OffsetY => offsetY;
    public float OffsetZ => offsetZ;

    public OffsetType FOffsetType => offsetType;
    public MovementType FMovementType => movementType;
    public Settings(float _speed)
    {
        movementType = MovementType.Lerp;
        offsetType = OffsetType.World;
       speed = _speed;
       offsetX = offsetY =  offsetZ = 0;

    }

    #endregion settings
    // float a; //ne peut être initaliser que dans le constructeur ou à l'instance de la struct
    // public CameraSettings(float _a)
    // {
    //    a = _a;
    //}
}

public class CameraTargetNullReferenceException : NullReferenceException
{
    public override string Message => "Not target for camera: NullReferenceException";
}

public abstract class CameraMovement : MonoBehaviour
{

    #region settings
    [SerializeField]
    protected Transform target = null;

    [SerializeField]
    protected CameraSettings CameraSettings = null;
    [SerializeField]
    protected Settings Settings = new Settings(2);

   
    #endregion settings

    #region Debug
    [SerializeField, Header("Debug")] protected bool useDebug = true;
    [SerializeField]  protected Color validDebugColor = Color.green, novalidDebugColor = Color.red;
    // [SerializeField] AnimationCurve Curve;

    #endregion Debug

    #region Properties
    public bool IsValid => target;
    public virtual  Vector3 CurrentPosition => transform.position;
    public  virtual Vector3 TargetPosition
    {
        get
        {
            if (!target)
                throw new CameraTargetNullReferenceException();
            return target.position;
        }

    }
    public virtual Vector3 FinaltPosition => TargetPosition + Offset;

    public virtual Vector3 Offset =>  Vector3.zero;
  
  
    #endregion Properties

    #region Method
  
    
    private void LateUpdate() => UpdateCameraPosition();
    /// <summary>
    /// Target can not Object
    /// </summary>
    /// <exception cref="CameraTargetNullReferenceException"></exception>
    protected virtual void UpdateCameraPosition()
    {
        Vector3 _fwd = (TargetPosition - transform.position).normalized;
        Vector3 _right = Vector3.Cross(Vector3.up, _fwd).normalized;
        Vector3 _up = Vector3.Cross(_fwd, _right);
        Matrix4x4 _matrix = new Matrix4x4(_right, _up, _fwd, new Vector4(0,0, 0, 1));
        transform.rotation = _matrix.rotation;
       // transform.rotation = Quaternion.Lerp(_matrix.rotation, transform.rotation, Time.deltaTime); ;
    }
    private void OnDrawGizmos()
    {
        DrawDebugMovement();
        DrawAxis();
    }

    protected virtual void DrawDebugMovement()
    {
        DrawAxis();
    }
    protected Vector3 GetLocalOffset(float _x, float _y, float _z) => target.right* _x+ target.up * _x+ target.forward * _x;
        
    void DrawAxis()
    {
        //behaviour cameraSettings
        if (!useDebug) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(TargetPosition, TargetPosition + target.right * 2);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(TargetPosition, TargetPosition + target.up * 2);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(TargetPosition, TargetPosition + target.forward * 2);
    }
    protected T CastSettings<T>(CameraSettings _settings) where T : CameraSettings => (T)_settings;


    #endregion
    /*
     * MPDDialogCameraSystem
     * if(!camerActive)
     *      return;
     *      
     *   
     *      
     * UpdateCameraLocation
     * cameraActive.SetDestination(FinalCameraLocation);
     * cameraActive.SetLookAt(TargetPivot);
     * 
     * 
     * Update
     *  
     *  Quaternion _fwd = Quaternion.LookRotation(TargetPivot - transform.position);
     *  transform.rotation = Quaternion.Lerp(transform?rotation, _fwd, Time.deltatime);
     *  
     *  
     *  transform.rotation = Quaternion.Euler
     *      Eler to quaternion
     * 
     * 
     * 
     * 
     */
    #region Distance
    /*
     * 
        [SerializeField, Range(-10,10)]
         float distance = 2.0f;

        Vector3  GetRelativePoint(float _distance) => Vector3.right * _distance;
        Vector3 GetRelativePoint_two(float _distance) => new Vector3(_distance, 0, 0);
        Vector3 GetRelativePoint_three(float _distance) => Vector3.zero +new Vector3(_distance, 0, 0);
        Vector3 GetRelativePoint_four(float _distance)=> new Vector3(Mathf.Cos(270*Mathf.Deg2Rad) * _distance, Mathf.Sin(270 
            * Mathf.Deg2Rad) * _distance, 0);
        Vector3 GetRelativePoint_five(float _distance) =>new Vector3(_distance, _distance, _distance);

        private void OnDrawGizmos() //Se calcule tous le temps utilise la refresh
        {
            #region ok
            //Origin world
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Vector3.zero, 1);

            //Object
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 0.2f);
            #endregion

            //destination

            Vector3 point = new(3, 10, 8);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, point);

            Vector3 position = transform.position - point+ GetRelativePoint_five(distance);


            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(point-position, 0.2f);
        }
        */
    #endregion Distance
}



