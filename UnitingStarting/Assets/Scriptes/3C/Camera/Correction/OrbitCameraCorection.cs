using UnityEngine;

public class OrbitCameraCorection : CameraMovement
{
    public override Vector3 FinaltPosition => RotationPoint() +TargetPosition;
     float angle = 0;
  
   
    protected override void UpdateCameraPosition()=> transform.position = FinaltPosition;
    protected override void DrawDebugMovement()
    {
        CameraOrbitSettings _set = CastSettings<CameraOrbitSettings>(CameraSettings);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, TargetPosition);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(TargetPosition, _set.Radius);
    }

    Vector3 RotationPoint()
    {
        CameraOrbitSettings _set = CastSettings<CameraOrbitSettings>(CameraSettings);
        float _radius = _set ? _set.Radius : 1;
        angle = ComputeAngle();
        float _x = Mathf.Cos(angle * Mathf.Deg2Rad) * _radius,
               _z = Mathf.Sin(angle * Mathf.Deg2Rad) * _radius;
        return new Vector3(_x, 0, _z);
    }

    float ComputeAngle() => CastSettings<CameraOrbitSettings>(CameraSettings).Expression.Evaluate(Time.time) *360;
}   
