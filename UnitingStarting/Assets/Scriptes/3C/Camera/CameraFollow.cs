using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.SceneView;

public class CameraFollow : CameraMovement
{

    protected override void UpdateCameraPosition()
    {
        if (cameraSettings.FMovementType == CameraSettings.MovementType.Lerp)
            transform.position = Vector3.Lerp(CurrentPosition, FinaltPosition, cameraSettings.Speed * Time.deltaTime);  //Time.time;
        else
            Vector3.MoveTowards(CurrentPosition, FinaltPosition, cameraSettings.Speed * Time.deltaTime);
    }
    protected override void DrawDebugMovement()
    {
        base.DrawDebugMovement();
        if (!useDebug) return;
        Gizmos.color = IsValid ? validDebugColor : novalidDebugColor; //attention Color == new même si chaque tick garbage
        Gizmos.DrawWireCube(CurrentPosition, Vector3.one * 0.2f);
        if (!IsValid) return;

        Gizmos.DrawLine(CurrentPosition, FinaltPosition);
        Vector3 _targetGizmo = FinaltPosition + Vector3.up;
        Gizmos.DrawSphere(_targetGizmo, 0.3f);


        Gizmos.DrawLine(FinaltPosition, _targetGizmo);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(CurrentPosition, TargetPosition);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(FinaltPosition, TargetPosition);
        Gizmos.DrawCube(FinaltPosition, Vector3.one * 0.1f);
    }
}
