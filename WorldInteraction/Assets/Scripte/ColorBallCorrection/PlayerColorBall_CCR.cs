using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerColorBall_CCR : MonoBehaviour
{
    [SerializeField] float lifeSpan = 2;
    [SerializeField] Rigidbody ballPhysics = null;
    [SerializeField] Renderer ballRenderer = null;
    [SerializeField]
    Color ballColor;
   public void InitBall(Color _ballColor, int _force)
    {
        ballColor = _ballColor;
        ballRenderer.material.color = _ballColor;    
        Destroy(gameObject, lifeSpan);
        ballPhysics.AddForce(transform.forward * _force, ForceMode.Impulse);

    }

    private void OnTriggerEnter(Collider other)
    {
        ColorItem_CCR  _item = other.GetComponent<ColorItem_CCR>();
        if (!_item)
            return;
        _item.SetColor(ballColor);
        Destroy(gameObject);
    }
}
