using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightCircleSensorComponent : SightSensorComponent
{
    public override void UpdateSight()
    {
        Collider[] _items = Physics.OverlapSphere(PositionOffset, range, mask);

      

        Collider(_items);
    }

    protected override void DrawDebug()
    {
        if (!onDrawDebug)
            return;
        Gizmos.color = hit? Color.red : Color.white;
        Gizmos.DrawWireSphere(PositionOffset, range);
    }
    private void Collider(Collider[] _items) 
    {
        if (_items.Length > 0)
        {
            hit = true;
            Target = _items[0].gameObject;
            OnTarget?.Invoke(Target);
            return;
        }

         hit = false;
    }
}
