using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamZoneTrigger : MonoBehaviour, IManagedItem<string>
{

    public event Action<CameZonePlayer> OnPlayerEnter = null,
                                        OnPlayerExit = null;
    
    [SerializeField] CamZoneCamera zoneCamera = null;
    [SerializeField] Collider triggerZone = null;
    [SerializeField] string id = "camZone";
    public string ID => id;
    private void Awake()=> OnPlayerEnter += TriggerCamera; 
    
    private void Start() => Register();
    
    private void OnTriggerEnter(Collider other)
    {
        CameZonePlayer _p = other.GetComponent<CameZonePlayer>();
        
        if (!_p)
            return;
       
        OnPlayerEnter?.Invoke(_p);
    }
    private void OnTriggerExit(Collider other)
    {

        CameZonePlayer _p = other.GetComponent<CameZonePlayer>();
        
        if (!_p)
            return;

        OnPlayerExit?.Invoke(_p);
    }
    private void OnDrawGizmos()
    {
        if (!triggerZone)
            return;

        Gizmos.color = new(0, 1, 0, 1);
        Gizmos.DrawWireCube(transform.position, triggerZone.bounds.size);
        Gizmos.color = new(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, triggerZone.bounds.size);
    }
   public void Register() 
    {
        if (!zoneCamera)
            throw new System.NullReferenceException("CamZoneTrigger =>  missing zoneCamera");

        if (!triggerZone)
            throw new System.NullReferenceException("CamZoneTrigger =>  missing triggerZone");
        CamZoneManager.Instance.Add(this);
        Disable();
    }
   public void Enable() => zoneCamera.EnableView( true);
    
   public void Disable() => zoneCamera.EnableView(false);
    
    public virtual void TriggerCamera(CameZonePlayer _player)
    {
       
        CamZoneManager.Instance.Enable(id);
        zoneCamera.SetTarget(_player.transform);
    }
}
