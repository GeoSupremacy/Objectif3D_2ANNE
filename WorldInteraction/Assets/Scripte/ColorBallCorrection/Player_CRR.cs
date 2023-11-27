using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CRR : MonoBehaviour
{
    [SerializeField] PlayerShooter_CCR shootBehaviour = null;
    [SerializeField] CharacterController characterController = null;


    private void Start()=>Cursor.lockState = CursorLockMode.Confined;
    
    void Update() 
    { 

        Player();
        Movement();
    }
    void Movement()
    {
        float _axis = Input.GetAxis("Vertical");
        characterController.SimpleMove(transform.forward * _axis);
        float _xAxis = Input.GetAxis("Mouse X"),
                _yAxis = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-_yAxis, _xAxis,0);
    }
    void Player()
    {
        bool _leftAction = Input.GetKeyDown(KeyCode.Mouse0);
        bool _rightAction = Input.GetKeyDown(KeyCode.Mouse1);
        if(_leftAction)
        shootBehaviour.Shoot(0);
        if(_rightAction)
        shootBehaviour.Shoot(1);
    }
}
