using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(InputComponant))]
[RequireComponent(typeof(Rigidbody))]

[RequireComponent(typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    public static Action<float> onMoveForward;
    public static Action<float> onStopForward;
    public static Action<string> onOpenDialog;
    public static Action onLeftDialog;
    #region Settings
    [SerializeField]
    InputComponant inputPlayer;
    [SerializeField]
        CameraCustom cameraCustom;
    [SerializeField]
        SpringArm arm = null;
   
    [SerializeField, Range(1, 100), Min(0)]
    float speedForward = 5,
          speedRight = 5,
          speedCameraX = 5,
          speedCameraY = 5;
    [SerializeField, Range(1, 1000), Min(0)]
    float ThrustJump =1000;
    [SerializeField, Range(0, 1000), Min(0)]
    float touchGround = 1000;
    [SerializeField] float minAngle, maxAngle;
    [SerializeField]
    bool canJump = true;
    [SerializeField]
    LayerMask layerJump, layerInteract;
    #endregion Settings

    #region METHOD_UNITY

    void Start() => Init();
    void Update() => AllMovement();
    private void LateUpdate()
    {
        IsGround();
    }
   
    private void OnDrawGizmos() => DrawDebug();
    #endregion METHOD_UNITY

    #region Movement
    void AllMovement()
    {
        MoveForward();
        MoveRight();
        RotateYaw();
        RotatePitch();
       
    }
    void MoveForward()
    {
        
        if(!inputPlayer)
            throw new System.NullReferenceException("Not input Player");

        float _axis = inputPlayer.MoveForward.ReadValue<float>();
       
        float _speed = _axis * (speedForward * Time.deltaTime);
        transform.position += transform.forward* _speed;
    
        onMoveForward?.Invoke(_axis);
    }
    void MoveRight()
    {
        if (!inputPlayer)
            throw new System.NullReferenceException("Not input Player");
        float _axis = inputPlayer.MoveRight.ReadValue<float>();
        float _speed = _axis * (speedRight * Time.deltaTime);
        transform.position += transform.right * _speed;
    }
    void RotateYaw()
    {
        if (!inputPlayer || !cameraCustom)
            throw new System.NullReferenceException("No cameraCustom or input");
        float _rotValueY = inputPlayer.RotateYaw.ReadValue<float>();
        float speed = _rotValueY * (speedCameraX * Time.deltaTime);


        arm.transform.eulerAngles += transform.up * speed;
    }
    void RotatePitch()  
    {
        if (!inputPlayer || !cameraCustom)
            throw new System.NullReferenceException("No cameraCustom or input");

        float _rotValueX = inputPlayer.RotatePitch.ReadValue<float>();
        float speed = _rotValueX * (speedCameraY * Time.deltaTime);
        arm.transform.eulerAngles += transform.right * speed;
    }
    #endregion Movement

    #region Interact
    void Jump(InputAction.CallbackContext _context)
    { 
        if (!inputPlayer)
            throw new System.NullReferenceException("No cameraCustom or input");
        if(!canJump) 
            return;

        gameObject.GetComponent<Rigidbody>().AddForce(transform.up * ThrustJump);
    }
    void Interact(InputAction.CallbackContext _context)
    {
      
        if (!inputPlayer)
            throw new System.NullReferenceException("No cameraCustom or input");
        
        Ray _ray = new(transform.position + new Vector3(0, 1, 0), transform.forward);
        bool _isHit=  Physics.Raycast(_ray, out RaycastHit _result, 3, layerInteract);
        if(_isHit)
        {
           
            string _id = _result.collider.GetComponent<PNJ>().ID;
            onOpenDialog?.Invoke(_id);
        }
      
    }
    void LeftChat(InputAction.CallbackContext _context)
    {
        if (!inputPlayer)
            throw new System.NullReferenceException("No cameraCustom or input");
       
        onLeftDialog?.Invoke();
    }
    
    #endregion 

    #region INIT
    void Init()
    {
        arm.transform.position = transform.position;
        inputPlayer.Jump.performed += Jump;
        inputPlayer.Interact.performed += Interact;
        inputPlayer.Leftchat.performed += LeftChat;
    }
   void IsGround()
    {
      bool _isHit=  Physics.Raycast(new(transform.position, -transform.up), out RaycastHit _result, touchGround, layerJump);
       
        _isHit = _isHit ==false ? canJump = false: canJump = true;
        
    }
   
    #endregion 

    void DrawDebug()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, -transform.up * touchGround);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position+new Vector3(0,1,0), transform.forward * 3);
    }
}
