using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
     public Action<Player> OnAgressif = null;

    [SerializeField] InputComponent inputs = null;
    void Start()=> Init();
    
    void Init()
    {
        inputs = GetComponent<InputComponent>();
        inputs.ActionAgressif.performed += ActionAgressif;
    }

    void ActionAgressif(InputAction.CallbackContext _context)
    {
       
        OnAgressif?.Invoke(this);
    }

    private void OnDestroy()
    {
        OnAgressif = null;
    }
}
