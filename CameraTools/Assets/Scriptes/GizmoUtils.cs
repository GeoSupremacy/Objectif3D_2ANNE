using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoUtils
{
    public static void DrawCircle(Vector3 _origin, float _radius, Color _color, int _definition = 20)
    {
        Gizmos.color = _color;
        int _part = 360 / _definition;
        for (int i = 0; i <= _definition; i++)
        {
            float _a = (_part * i) * Mathf.Deg2Rad,
                _b = (_part * (i + 1)) * Mathf.Deg2Rad;
            Vector3 _from = new Vector3(Mathf.Cos(_a) * _radius, 0, Mathf.Sin(_a) * _radius),
                _to = new Vector3(Mathf.Cos(_b) * _radius, 0, Mathf.Sin(_b) * _radius);
            Gizmos.DrawLine(_from + _origin, _to + _origin);
        }
        Gizmos.color = Color.white;
    }
}