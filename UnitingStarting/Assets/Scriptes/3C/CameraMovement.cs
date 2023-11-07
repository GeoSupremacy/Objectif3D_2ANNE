using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraTargetNullReferenceException : NullReferenceException
{
    public override string Message => "Not target for camera: NullReferenceException";
}

[SerializeField]
public  enum Interpolation
{
    North,
    East,
    South,
    West
}
public class CameraMovement : MonoBehaviour
{
    #region settings
    [SerializeField] Transform target = null;
    [SerializeField, Header("Camera settings"), Range(-20, 20)]
    private Interpolation Interpolation;
    float distancetarget = 3;

    #endregion settings

    #region Debug
    [SerializeField, Header("Debug")] bool useDebug = true;
    [SerializeField] Color validDebugColor = Color.green, novalidDebugColor = Color.red;
    [SerializeField] AnimationCurve Curve;

    #endregion Debug

    #region Properties
    public bool IsValid => target;
    Vector3 CurrentPosition => transform.position;
    Vector3 FinaltPosition => target? target.position +Offset : CurrentPosition;

    public Vector3 Offset => new Vector3(distancetarget, 0, 0);
    #endregion Properties

    private void LateUpdate() => UpdateCameraPosition();
    /// <summary>
    /// Target can not Object
    /// </summary>
    /// <exception cref="CameraTargetNullReferenceException"></exception>
    private void UpdateCameraPosition()
    {
        if (!target)
            throw new CameraTargetNullReferenceException();
        //  transform.position += TweenerLibrary.StartMoveTo(this, CurrentPosition, Vector3.zero, TweenerFunction.Easing.other, ()=> );  //Time.time;
    }
    private void OnDrawGizmos() 
    { 
        DrawDebugMovement(); 
    }
    void DrawDebugMovement()
    {
        if (!useDebug) return;
        Gizmos.color = IsValid ? validDebugColor : novalidDebugColor; //attention Color == new même si chaque tick garbage
        Gizmos.DrawWireCube(CurrentPosition, Vector3.one * 0.2f);
        if(!IsValid) return;

        Gizmos.DrawLine(CurrentPosition, FinaltPosition);
        Vector3 _targetGizmo= FinaltPosition + Vector3.up;
        Gizmos.DrawSphere(_targetGizmo, 0.3f);

        Gizmos.DrawLine(FinaltPosition, _targetGizmo);
    }

    #region Distance
    /*
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



