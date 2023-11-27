using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody playerController = null;
    [SerializeField, Range(0,200)] float speed = 100;

    Animator animator;
    private void Update()
    {
        animator.SetFloat("", playerController.velocity.normalized.magnitude, 0.5f, Time.deltaTime);
        playerController.velocity = Vector3.ClampMagnitude(playerController.velocity, 1);
        MoveCharacter();
        RotateCharacter();
    }
    private void MoveCharacter()
    {
        float _axis = Input.GetAxis("Vertical");
        playerController.AddForce(transform.forward * speed*_axis);
    }
    void RotateCharacter()
    {
        float _axis = Input.GetAxis("Horizontal");
        playerController.AddTorque(transform.up * _axis, ForceMode.Impulse);
    }
}
