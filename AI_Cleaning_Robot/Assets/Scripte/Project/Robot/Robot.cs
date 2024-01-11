using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Robot : MonoBehaviour
{

    public Action onDeath;

    #region f/p
    [field: SerializeField] Garbage garbage;
    [SerializeField] private LayerMask hitLayer;
    [SerializeField]
    Vector3 position;
    [SerializeField, Range(0, 100)]
    float distance = 5;
    [SerializeField, Range(0, 100)]
    float speed = 5;
    #endregion

    #region Acesseur
    Vector3 RobotPosition => position + transform.position;
    public void SetRotate(Quaternion _rotate) => transform.rotation = _rotate;
    [field: SerializeField]
    public Vector3 NextMove { get; set; }
    public bool IsGarbage { get; private set; }
    [field: SerializeField]
    public bool Move { get; set; }
    #endregion

    #region UNITY_METHOD
    private void Awake()
    {
        GarbageManager.OnDeaths += DeadAnimation;
    }
    private void Start() => Move = false;
    void Update()
    {
        GarbageDetected();
        MoveTo();
        Collect();
    }
    private void OnDrawGizmos() => DrawDebug();
    private void OnDestroy()
    {
        garbage = null;
        onDeath = null;
    }
    #endregion

    #region METHOD
    void Collect()
    {
        if (garbage == null || !Destination())
            return;


        Move = IsGarbage = false;
        garbage.Collected();
        garbage = null;
    }
    void MoveTo()
    {
        if (Destination())
        {
            Move = false;
            return;
        }

        if (Move)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void GarbageDetected()
    {
        if (IsGarbage)
            return;

        bool _hit = Physics.Raycast(new(RobotPosition, transform.forward), out RaycastHit _result, distance, hitLayer);
        if (_hit)
        {

            Move = true;
            IsGarbage = true;
            garbage = _result.collider.gameObject.GetComponent<Garbage>();
            NextMove = garbage.transform.position;
            Look();

        }
    }
    public bool Destination()
    {
        Vector3 _relativePosition = NextMove;

        _relativePosition = _relativePosition - transform.position;
        return (math.abs(Length(_relativePosition)) <= 0.5f);
    }
    float Length(Vector3 _tr) => Mathf.Sqrt(Mathf.Pow(_tr.x, 2) + Mathf.Pow(_tr.y, 2) + Mathf.Pow(_tr.z, 2));
    public void Look()
    {
        Vector3 _relativePosition = NextMove - transform.position;
        Quaternion rotation = Quaternion.LookRotation(_relativePosition, Vector3.up);
        rotation = new(0, rotation.y, 0, rotation.w);
        transform.rotation = rotation;
    }
    void DrawDebug()
    {
        Color _color;
        Ray _r = new(RobotPosition, transform.forward);
        bool _hit = Physics.Raycast(_r.origin, _r.direction, out RaycastHit _result, distance, hitLayer);
        if (_hit)
            _color = Color.white;

        else
            _color = Color.red;


        Gizmos.color = _color;
        Gizmos.DrawSphere(NextMove, 0.5f);
        Gizmos.DrawRay(_r.origin, _r.direction * distance);

        if (IsGarbage)
        {
            Vector3 _tr = transform.position + transform.up * 4;
            Gizmos.DrawSphere(_tr, 0.5f);
        }

    }
    public void Dead()
    {
        IsGarbage= Move = false;
        Destroy(this.gameObject); 
    }
    
    public void DeadAnimation()
    { onDeath?.Invoke(); }
  #endregion
}
