using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RobotSightSensorComponent : SightSensorComponent
{

    Vector3 LeftCone => PositionOffset + Quaternion.Euler(0, -sightAngle/2,0) *transform.forward* range;
    Vector3 RightCone => PositionOffset + Quaternion.Euler(0, sightAngle / 2, 0) * transform.forward * range;
    Vector3 HightCone => PositionOffset + Quaternion.Euler(sightAngle / 2, 0, 0) * transform.forward * range;
    Vector3 GroundCone => PositionOffset + Quaternion.Euler(-sightAngle / 2, 0, 0) * transform.forward * range;
    

    [SerializeField] bool hit = false;
    public override void UpdateSight()
    {
        hit = false;
        Collider[] _items = Physics.OverlapSphere(PositionOffset, range, mask);

       
      //  DrawLine();
        Colliders(_items);
    }
    protected override void DrawDebug()
    {
        if (!onDrawDebug)
            return;

        UpdateSight();
        
        float _range = (math.abs(LeftCone - RightCone).x);
        Gizmos.color = hit ? Color.white : Color.red;
        Gizmos.DrawWireSphere(PositionOffset, range);
       Utils.DrawCircleAroundZ(PositionOffset + transform.forward * _range / 2, PositionOffset, _range / 2, Color.red, definition);
    }
    void DrawLine()
    {
        Debug.DrawLine(PositionOffset, LeftCone, Color.red);
        Debug.DrawLine(PositionOffset, GroundCone, Color.red);
        Debug.DrawLine(PositionOffset, RightCone, Color.green);
        Debug.DrawLine(PositionOffset, HightCone, Color.green);
        Debug.DrawLine(HightCone, GroundCone, Color.magenta);
        Debug.DrawLine(LeftCone, RightCone, Color.magenta);
        Debug.DrawLine(LeftCone, GroundCone, Color.magenta);
        Debug.DrawLine(LeftCone, HightCone, Color.magenta);
        Debug.DrawLine(GroundCone, RightCone, Color.magenta);
        Debug.DrawLine(RightCone, HightCone, Color.magenta);
    }
    void  Colliders(Collider[] _items)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            Vector3 _direction = (_items[i].transform.position - PositionOffset).normalized;
            Debug.DrawLine(_items[i].transform.position, PositionOffset, Color.black);
            float _angle = Vector3.Angle(transform.forward, _direction);


            if (_angle < sightAngle / 2)
            {
                hit = true;
                Target = _items[i].gameObject;
                return;
            }

        }
    }
   

}
