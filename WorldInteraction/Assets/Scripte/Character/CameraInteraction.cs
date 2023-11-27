using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class CameraInteraction : MonoBehaviour
{
    [SerializeField] private Camera cameraOrigin =null;
    [SerializeField] private Transform target = null;
    [SerializeField] Vector2 viewport = Vector2.zero;
    [SerializeField] private float depth = 5;
    [SerializeField] private Slider slider = null;
    [SerializeField] private float sentivity  = -1f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField, Category("Color")] private ColorBlock ColorBlock;
    [SerializeField, Category("Color")] private ColorBlock ColorA;
    float rottionY;
    float rottionX;
    Quaternion CameraRotation { get { return cameraOrigin.transform.rotation; } set { cameraOrigin.transform.rotation = value; } }
   private void Update() => View();
    void View()
    {
        //ViewportToWorldCameraInteract();
        //RaycastViewportView();
        RaycastTarget();
        RotationCamera();
    }
    void ScreenToWorldCameraInteract()
    {
        Vector3 _input =new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Vector3 _position= cameraOrigin.ScreenToWorldPoint(_input);
        target.position = _position;
    }
    void ViewportToWorldCameraInteract()
    {
        Vector3 _input = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Vector3 _pos = new Vector3(viewport.x, viewport.y, depth);
        Vector3 _position = cameraOrigin.ViewportToWorldPoint(_input);
        target.position = _position;
    }
    void RaycastView()
    {
        Vector3 _input = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Ray _r = cameraOrigin.ScreenPointToRay(_input);

        bool _hit =Physics.Raycast(_r.origin, _r.direction, out RaycastHit _result);
        Debug.Log(_hit? _result.collider.name: "no hit");
    }
    void RaycastViewportView()
    {
        Vector3 _pos = new Vector3(viewport.x, viewport.y, depth);
        Vector3 _position = cameraOrigin.ViewportToWorldPoint(_pos);
        Ray _r = cameraOrigin.ScreenPointToRay(_pos);

        bool _hit = Physics.Raycast(_r.origin, _r.direction, out RaycastHit _result);
        Debug.Log(_hit ? _result.collider.name : "no hit");
    }
    void RaycastTarget()
    {
        Vector3 _input = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Ray _r = cameraOrigin.ScreenPointToRay(_input);

        bool _hit = Physics.Raycast(_r.origin, _r.direction, out RaycastHit _result, layerMask);
        //slider.colors;
    }
    void RotationCamera()
    {
        rottionY = Input.GetAxis("Mouse X");
        rottionX = Input.GetAxis("Mouse Y");
        Vector3 rotate = new Vector3(rottionX, rottionY * sentivity, 0);
        //Vector3 _input = cameraOrigin.ScreenToWorldPoint(new Vector3(0, Input.mousePosition.x, Input.mousePosition.y));
        //_input += Vector3.zero - _input;
        // Debug.Log($"X: {_input.x} Y: {_input.y} Z: {_input.z} "); new Quaternion(0,rottionX, rottionY,1)
        cameraOrigin.transform.eulerAngles = cameraOrigin.transform.eulerAngles - rotate;
    }
    #region OnDrawGizmos
    private void OnDrawGizmos() => DrawDebug();
    private void DrawDebug()
    {
        Vector3 _input = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Ray _r = cameraOrigin.ScreenPointToRay(_input);

        bool _hit = Physics.Raycast(_r.origin, _r.direction, out RaycastHit _result, layerMask);

        Gizmos.color = _hit ? Color.green : Color.red;
        Gizmos.DrawRay(_r.origin, _r.direction *20);
    }
    #endregion
}
