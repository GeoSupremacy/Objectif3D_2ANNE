using System;
using System.Collections;
using UnityEngine;



public class RobotClean : Robot
{
    public Action onDeathAnimation;
    public Action<bool> onColllectAnimation;

    #region f/p
    [field: SerializeField] public Garbage Garbage { get; private set; }
    
  
   
    #endregion
 
    public bool IsGarbage { get; private set; }
    private void OnDestroy() => Delete();
    protected override void Update()
    {
        base.Update();
        if (!sightSensorComponent)
            return;
       
        Collect();
        GarbageDetected();
       
    }


    void Delete()
    {
        Garbage = null;
        onDeathAnimation = null;
    }
    void Collect()
    {
        if (!Garbage || !Destination)
            return;

       
        Move = IsGarbage = false;
        Garbage.Collected();
        Garbage = null;
        sightSensorComponent.ClearnSight();
        onColllectAnimation?.Invoke(true);
    }
   public  void EndCollected()=> onColllectAnimation?.Invoke(false);
    void GarbageDetected()
    {
        if (!IsGarbage)
            if (Detection)
                Patrol();

        
    }
    protected override void Patrol() 
    {
        IsGarbage = true;
        Garbage = sightSensorComponent.Target.GetComponent<Garbage>();
        NextMove = Garbage.Position;
        base.Patrol();
    }
    protected override void Init() 
    {
        sightSensorComponent = this.GetComponent<RobotSightSensorComponent>(); 
    }

    protected override void DrawDebug()
    {
      if(IsDead) 
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(NextMove, 0.5f);
        if (IsGarbage)
        {
            Gizmos.color = Color.blue;
            Vector3 _tr = transform.position + transform.up * 4;
            Gizmos.DrawSphere(_tr, 0.5f);
        }
    }
    public override void Dead()
    {
        
        IsGarbage = false;
        base.Dead();
       
    }
   
    public void DeadAnimation()=> onDeathAnimation?.Invoke();
    protected override void Bind()
    {
        base.Bind();
        GarbageManager.OnDeaths += DeadAnimation;
        GarbageManager.OnDeaths += Stop;
    }
}
