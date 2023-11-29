using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class DiabloCharacter : MonoBehaviour
{
    [SerializeField, Category("Diablo/Camera")] 
        private Camera camera = null;
    [SerializeField, Category("Diablo/LayerMask")] 
        private LayerMask hitLayer;
    [SerializeField, Category("Diablo/LayerMask"), Range(0,100)]
        private float pointRange;
    [SerializeField]
    private float mouseX, mouseY;

    [SerializeField] Vector3 viewport = Vector3.zero;
    [SerializeField, Range(0, 100)] float depth = 1.0f;
    bool isHit = false;
    Vector3 hitPoint;
    public Vector3 CameraPosition => camera.transform.position;
    public Vector3 CameraForward => camera.transform.forward;
    private void Update()
    {
    
        MousePosition();
       
    }
    void CameraIntract()
    {
     
        Vector3 _input = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Vector3 _position = camera.ScreenToWorldPoint(_input);
     
    }
    private void OnDrawGizmos()
    {
        DrawDebug();
        CameraIntract();
    }
    void DrawDebug()
    {
        Vector3 _input = new Vector3(Input.mousePosition.x, Input.mousePosition.x, 5);
        Vector3 _position = camera.ScreenToWorldPoint(_input);
        if(isHit)
        Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;
        Ray _r = new Ray(CameraPosition, -_position);
        Gizmos.DrawRay(_r.origin, _r.direction * pointRange);
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(_position, .25f);
    }

    #region Move
   
    void MousePosition()
    {
        
        Vector3 _input = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 _position = camera.ScreenToWorldPoint(_input);

       
        isHit = Physics.Raycast(new Ray(CameraPosition, -_position), out RaycastHit _result, pointRange, hitLayer);
        // ~Destructor of layer == !layer
        // no layermask on collider



        if (isHit)
        {
            //T _get = _result.collider.getComponent<T>();
            Debug.Log($"{pointRange = _result.distance} {_result.collider.name} {hitPoint = _result.point}");
        }
    }
  
    #endregion Move

}
