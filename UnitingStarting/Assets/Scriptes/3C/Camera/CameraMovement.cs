using System;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public struct CameraSettings
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
    public CameraSettings(float _speed)
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
    protected CameraSettingsData cameraSettingsData = null;
    [SerializeField]
    protected CameraSettings cameraSettings = new CameraSettings(2);
    [SerializeField]
    public Transform target = null;
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
  
    public Vector3 Offset 
    {
        get 
        {
            if (cameraSettings.FOffsetType == CameraSettings.OffsetType.Local)
            return GetLocalOffset(cameraSettings.OffsetX, cameraSettings.OffsetY,cameraSettings.OffsetZ);
            
            else
              return new Vector3(cameraSettings.OffsetX, cameraSettings.OffsetY, cameraSettings.OffsetZ);
        }
        
}
    #endregion Properties

    #region Method
   // private void Start()=> target.SetPosition(Offset);
    
    private void LateUpdate() => UpdateCameraPosition();
    /// <summary>
    /// Target can not Object
    /// </summary>
    /// <exception cref="CameraTargetNullReferenceException"></exception>
    protected virtual void UpdateCameraPosition()
    {
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
    #endregion
    
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



