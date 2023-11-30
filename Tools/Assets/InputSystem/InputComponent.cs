using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class InputComponent : MonoBehaviour
{
    [SerializeField] MyInput controls = null;
    [SerializeField] InputAction move = null;
    [SerializeField] InputAction rotate = null;
    [SerializeField] InputAction fire = null;
    [SerializeField] InputAction rebind = null;


    [SerializeField] string overridingInput = "";
    [SerializeField] const string Filename = "Save all pass";


    [SerializeField] List<InputAction> allInputs = new List<InputAction>();
    public InputAction Move => move;
    public InputAction Rotate => rotate;
    public InputAction Fire => fire;

    private void Awake()
    {
        controls = new MyInput();
    }
    private void Start()
    {
        LoadOverridedInputs();
        rebind.performed += RebindFire;
    }
    private void OnEnable()
    {
        move = controls.Player.Movement;
        rotate = controls.Player.Rotate;
        fire = controls.Player.Fire;
        rebind = controls.Player.Rebind;

        allInputs.AddRange(new List<InputAction> { move, rotate,fire , rebind });
        ManageInputActivation(true);
    }
    private void OnDisable()
    {
        ManageInputActivation(false);
    }

    void ManageInputActivation(bool _value)
    {
        foreach (var input in allInputs) 
        {
            if (_value)
                input.Enable();
            else input.Disable();
        }
    }

    void RebindFire(InputAction.CallbackContext _contet)
    {
        fire.Disable(); //Desactive sinon marche pas
        InputActionRebindingExtensions.RebindingOperation _rebindOps = fire.PerformInteractiveRebinding();
        _rebindOps.WithControlsExcluding("Mouse");
        _rebindOps.OnComplete(callback =>
        {
            
            callback.Dispose();//le garde sinon carsh
            fire.Enable();
            overridingInput = controls.SaveBindingOverridesAsJson();  //l'input n'aurais pas changer dans mappingInput
            File.WriteAllText(Filename, overridingInput);
        });
        Debug.Log("Enter new fire Input");
        _rebindOps.Start(); //Lance l'opération pou entrer input, détruit callback 
      
    }

    void LoadOverridedInputs()
    {
        if (!File.Exists(Filename))
            return;
        string json = File.ReadAllText(Filename);
        controls.LoadBindingOverridesFromJson(json);
    }
}
