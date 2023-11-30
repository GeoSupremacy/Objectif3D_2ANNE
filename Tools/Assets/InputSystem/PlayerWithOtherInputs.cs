using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWithOtherInputs : MonoBehaviour
{
    [SerializeField] InputActionAsset controls = null;
    [SerializeField] InputAction move = null;
    [SerializeField] InputAction rotate = null;
    [SerializeField] InputAction fire = null;


    private void Start()
    {
        Init();
    }
    private void Update()
    {
        Move();
        Rotate();
    }
    private void Init()
    {
       // inputs = GetComponent<InputComponent>();
    }
    private void Move()
    {
      /*  if (!inputs)
            return;
        Vector3 _moveDir = inputs.Move.ReadValue<Vector3>();

        transform.position += transform.forward * 5 * Time.deltaTime * _moveDir.z;*/
    }
    private void Rotate()
    {
      /*  if (!inputs)
            return;
        Vector3 _moveDir = move.ReadValue<Vector3>();

        transform.position += transform.forward * 5 * Time.deltaTime * _moveDir.z;*/
    }

    private void OnEnable()
    {
        move = controls.FindActionMap("Player").FindAction("Movement");
        move.Enable();
    }
}
