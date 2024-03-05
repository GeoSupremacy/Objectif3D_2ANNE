using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] InputComponent inputs = null;
    public InputComponent Inptus => inputs;
    float speedForward = 3.0f;
    void Start()=>  Init();

    private void Update() => Move();
    void Init()
    {
        inputs = GetComponent<InputComponent>();
    }
    void Move()
    {
        MoveForward();
    }

    void MoveForward()
    {
        if (!inputs)
            return;

        float _axis = inputs.MoveForward.ReadValue<float>();

        float _speed = _axis * (speedForward * Time.deltaTime);
        transform.position += transform.forward * _speed;

    }
}
