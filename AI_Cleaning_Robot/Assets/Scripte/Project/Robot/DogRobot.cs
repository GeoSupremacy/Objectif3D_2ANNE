using System.Collections;
using System.Diagnostics;
using UnityEngine;



public class DogRobot : Robot
{
   

  
    [field: SerializeField]
    public bool IsSavage { get; set; } = true;
    [field:SerializeField]
    public bool IsPassif { get; set; } = true;
    protected override void Init()
    { 
        sightSensorComponent = this.GetComponent<SightSensorComponent>();
        sightSensorComponent.OnTarget += SetFollower;
       
    }
  
    protected override void DrawDebug() 
    {
        if (!isDebug) return;

        DrawFollowTarget();
        DrawNextMove();


    }
    private void DrawNextMove()
    {
        if (!Move)
        { return; }
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(NextMove, 0.5f);
        Gizmos.DrawLine(NextMove, transform.position);
        Gizmos.color = Color.white;
    }
    void DrawFollowTarget()
    {
        Gizmos.color = Color.red;

        if (!Target)
            return;
        Gizmos.DrawSphere(transform.position + transform.up * 3, 0.5f);
        Gizmos.color = Color.white;
    }
}
