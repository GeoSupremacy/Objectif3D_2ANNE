using UnityEngine;

public class OrbitCameraCorection : CameraMovement
{
    public override Vector3 FinaltPosition => RotationPoint() +TargetPosition;

    [SerializeField, Header("Orbit settings"), Range(.1f,10)]
    float radius = 4.77f;
    [SerializeField] AnimationCurve expression;
    //{
       //  new Keyframe(0,0),
       // new Keyframe(0,0),
       //  new Keyframe(0,0),
   // }
       
   // );
    float angle = 0;
  //  [SerializeField, Range(.1f, 10)]
  //  float duration = 5;
    void InitExpressionDuration()
    {
      // if( expression.keys.Length ==2)
          //  expression.keys[1] = new Keyframe(duration, 1);
      /*  Keyframe _ko = expression.keys[0];
        Keyframe _k1 = expression.keys[1];
        expression.ClearKeys();
        expression.AddKey(_ko);
        _k1.time = duration;
        expression.AddKey(new Keyframe(duration/2, .5f));
        expression.AddKey(_k1);*/
        // expression.keys[1].time = duration;
    }
   // private void Start()
   // {
    //    InitExpressionDuration();
    //}
    protected override void UpdateCameraPosition()=> transform.position = FinaltPosition;
    protected override void DrawDebugMovement()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, TargetPosition);    
        Gizmos.DrawWireSphere(TargetPosition, radius);
    }

    Vector3 RotationPoint()
    {
        angle = ComputeAngle();
        float _x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius,
               _z = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
        return new Vector3(_x, 0, _z);
    }

    float ComputeAngle() => expression.Evaluate(Time.time) * 360;
}   
