using System.Collections;
using System.Diagnostics;
using UnityEngine;



public class DogRobot : Robot
{

    [ SerializeField]
    private Player player =null;

    [field: SerializeField]
    public bool IsSavage { get; set; } = true;
    [field:SerializeField]
    public bool IsPassif { get; set; } = true;
    protected override void Init()
    { 
        sightSensorComponent = this.GetComponent<SightCircleSensorComponent>();
        sightSensorComponent.OnTarget += SetFollower;
        player.OnAgressif += SetPassif;
    }
   
    private void SetPassif(Player _player)
    {
        Target = _player.gameObject;
        IsPassif = false;
        Move = true;
    }
    public override void Follow()
    {
        base.Follow();
      
        
    }
    protected override void DrawDebug() 
    {
        if (!isDebug) return;

        DrawFollowTarget();
        DrawNextMove();
        DrawAggressif();

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
    void DrawAggressif()
    {
        if(IsPassif) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 3 + transform.forward *3);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 3 + transform.forward * -3);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 3 + transform.right * -3);
        Gizmos.color = Color.white;
    }
}
