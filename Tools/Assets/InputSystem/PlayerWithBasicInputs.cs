using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWithBasicInputs : MonoBehaviour
{
    [SerializeField] InputComponent inputs = null;
    [SerializeField] bool isfiring = false;



    private void Start()
    {
        Init();
    }
    private void Update()
    {
        Move();
        Rotate();
        Shoot();
    }
    private void Init()
    {
        inputs = GetComponent<InputComponent>();
        if (!inputs)
            return;
        inputs.Fire.performed += Set;
    }
    private void Move()
    {
        if (!inputs)
            return;
        Vector3 _moveDir = inputs.Move.ReadValue<Vector3>();

        transform.position += transform.forward * 5 * Time.deltaTime * _moveDir.z;
        transform.position += transform.right * 5 * Time.deltaTime * _moveDir.x;
    }
    private void Rotate()
    {
        if (!inputs)
            return;
        float _roteValue = inputs.Rotate.ReadValue<float>();

        transform.localEulerAngles += transform.up * 5 * Time.deltaTime * _roteValue;
    }
    private void Shoot()
    {
        if (isfiring)
            return;
        Debug.Log("Shoot");
    }
    public void Set(InputAction.CallbackContext _context)
    {
        isfiring =_context.ReadValue<float>() != 0;
        
    }
 
}
