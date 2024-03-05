using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ARSpawnner : MonoBehaviour
{
    Action<GameObject> OnObjectSapwned = null;

    [SerializeField] private ARRaycastManager raycastManager =null;
    [SerializeField] private ARPlaneManager planeManager = null;
    [SerializeField] private ARAnchorManager anchorManager = null;

    [SerializeField] private Camera cam = null;
    [SerializeField] private GameObject arObject = null;
    [SerializeField] private Transform aim;

    float currentTime = 0;
    float maxTime = 2;
    AimConstraint cube = null;

    private bool alreadySpawnned = false;

    List<ARAnchor> anchors = new List<ARAnchor>();
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start() => Init();
    void Update() => ARLogic();
    private void OnDestroy()
    {
        OnObjectSapwned = null;
    }
    private void Init()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
        anchorManager = GetComponent<ARAnchorManager>();
    }
    private void ARLogic()
    {
        if (!cube) return;
        currentTime = 0;
        Ray _fromCamera = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f));
        bool _hit = raycastManager.Raycast(_fromCamera, hits, TrackableType.PlaneWithinPolygon);

        if(_hit)
        {
            ARRaycastHit _firstHit = hits[0];
            Pose _pose = _firstHit.pose;
            ARPlane _plane = planeManager.GetPlane(_firstHit.trackableId);
            ARAnchor _anchor = anchorManager.AttachAnchor(_plane, _pose);
            aim.position = _anchor.transform.position;
            if (Input.touchCount == 0)
                return;
            Touch _t = Input.GetTouch(0);
            if (_t.phase ==TouchPhase.Began)
            {
                Debug.Log("Touch phase");
            }
        }
    }
}
