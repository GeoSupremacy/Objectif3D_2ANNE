using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils 
{
    public static void DrawCircleAroundY(Vector3 _position, float _radius, Color _color, int _definition = 20)
    {
        Gizmos.color = _color;
        int _part = 360 / _definition;
        for (int i = 0; i <= _definition; i++)
        {
            float _a = (_part * i) * Mathf.Deg2Rad,
                _b = (_part * (i + 1)) * Mathf.Deg2Rad;
            Vector3 _from = new Vector3(Mathf.Cos(_a) * _radius, 0, Mathf.Sin(_a) * _radius),
                _to = new Vector3(Mathf.Cos(_b) * _radius, 0, Mathf.Sin(_b) * _radius);
            Gizmos.DrawLine(_from + _position, _to + _position);
        }
        Gizmos.color = Color.white;
    }
    //  Vector3 LeftCone => PositionOffset + Quaternion.Euler(0, -sightAngle/2,0) *transform.forward* range;
    public static void DrawCircleAroundZ(Vector3 _position, float _radius, Color _color, int _definition = 20)
    {
        Gizmos.color = _color;
        int _part = 360 / _definition;
        for (int i = 0; i <= _definition; i++)
        {
            float _a = (_part * i) * Mathf.Deg2Rad,
                  _b = (_part * (i + 1)) * Mathf.Deg2Rad;
            Vector3 _from = new Vector3(Mathf.Cos(_a) * _radius, Mathf.Sin(_a) * _radius, 0),
                _to = new Vector3(Mathf.Cos(_b) * _radius, Mathf.Sin(_b) * _radius, 0);

            Gizmos.DrawLine(_from + _position, _position);
            Gizmos.DrawLine(_from + _position, _to + _position);
        }
        Gizmos.color = Color.white;
    }
    public static void DrawCircleAroundZ(Vector3 _fromPosition, Vector3 _toPosition, float _radius, Color _color, int _definition = 20)
    {
        Gizmos.color = _color;
        int _part = 360 / _definition;
        for (int i = 0; i <= _definition; i++)
        {
            float _a = (_part * i) * Mathf.Deg2Rad,
                  _b = (_part * (i + 1)) * Mathf.Deg2Rad;
            Vector3 _from = new Vector3(Mathf.Cos(_a) * _radius, Mathf.Sin(_a) * _radius, 0),
                _to = new Vector3(Mathf.Cos(_b) * _radius, Mathf.Sin(_b) * _radius, 0);

            Gizmos.DrawLine(_from + _fromPosition, _toPosition);
            Gizmos.DrawLine(_from + _fromPosition, _to + _fromPosition);
        }
        Gizmos.color = Color.white;
    }
}
