using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerWithInputs : MonoBehaviour
{
    [SerializeField] PlayerInputs controls = null;
    [SerializeField] InputAction move = null;
    [SerializeField] InputAction rotate = null;
    [SerializeField] InputAction fire = null;
    [SerializeField] bool canAttack = false;
    // Start is called before the first frame update

    private void Awake()
    {
        controls = new PlayerInputs(); 
    }

    private void Start()
    {
        string _controlJson = File.ReadAllText("Save Fike path");
        controls.LoadBindingOverridesFromJson(_controlJson);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Attack();
    }
    void Move()
    {
        Vector3 _movementDirection = move.ReadValue<Vector3>();
        transform.position += transform.forward * 5f * Time.deltaTime * _movementDirection.z;
       
        transform.position += transform.right * 5f * Time.deltaTime * _movementDirection.x;
    }
    void FireProjectile(InputAction.CallbackContext _context)
    {
        Debug.Log("FIRRRRRRRRE");
    }
    void Rotate()
    {
        float _rotValue = rotate.ReadValue<float>();
        transform.eulerAngles += transform.up * 50f * Time.deltaTime * _rotValue;
    }
    void Attack()
    {
        if (!canAttack) return;
        Debug.Log("Attack");
    }
    void SetAttack(InputAction.CallbackContext _context)
    {
        canAttack = _context.ReadValueAsButton();
    }
    private void OnEnable()
    {
        move = controls.Player.Movement;
        move.Enable();
        rotate = controls.Player.Rotate;
        rotate.Enable();
        fire =controls.Player.Fire;
        fire.Enable();
        fire.performed += SetAttack;
        /*
        fire.Disable();
        InputActionRebindingExtensions.RebindingOperation _rebindOps = fire.PerformInteractiveRebinding();
        _rebindOps.WithControlsExcluding("Mouse");
        string _input ="";
        _rebindOps.OnComplete((callback) => 
        {
            Debug.Log(callback);
            fire.Enable();
            _input =controls.SaveBindingOverridesAsJson();
            File.WriteAllText("Save File Path", _input);
        });
        _rebindOps.Start();
        */
    }
    private void OnDisable()
    {
        move.Disable();
        rotate.Disable();
        fire.Disable();
    }
}
