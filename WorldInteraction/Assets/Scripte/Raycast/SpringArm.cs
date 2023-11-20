using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    #region Settings
    [SerializeField] Camera camera =null;
    [SerializeField, Range(0,100)] float distance = 5;
    [SerializeField] bool isDistance = true;
    [SerializeField] Transform player = null;
    [SerializeField] private LayerMask hitLayer;
    Vector3 futurPositionCamera = Vector3.zero;
    bool hit = false;
    #endregion

    #region Properties
    Vector3 TargetPivot => PlayerPosition + Vector3.up * distance;
    Vector3 TargetPivotOffset => PositionOffset + Vector3.up * distance;
    Vector3 PlayerPosition { get
        {
            if (!player)
                throw new System.NullReferenceException("SpringArm: Missing Player"); return player.position; } }
    Vector3 PositionOffset => transform.position - PlayerPosition;
    Vector3 Position => transform.position;
    Quaternion LoookAt => Quaternion.LookRotation(PlayerPosition - TargetPivot);
    #endregion
    #region Unity_Methods
    private void Start() => Init();
    private void LateUpdate() => HitRay();
    private void OnDrawGizmos() => DrawDebug();
    #endregion

    #region Custom_Methods
    private void Init()
    {
        if (!camera)
            throw new System.NullReferenceException("SpringArm: Missing camera");

        camera.enabled = true;
    }
    private void HitRay()
    {
        hit = Physics.Raycast(new(PlayerPosition, PositionOffset), out RaycastHit _result, distance, hitLayer);
        if (hit)
            transform.position = _result.point;
        else
            transform.position = TargetPivot;
        transform.rotation = LoookAt;
    }
    private void DrawDebug()
    {
        futurPositionCamera = TargetPivot;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(PlayerPosition, TargetPivotOffset);
        Gizmos.DrawWireSphere(TargetPivot, 0.5f);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(TargetPivot, PlayerPosition + Vector3.up * 2);
    }
    #endregion
}
