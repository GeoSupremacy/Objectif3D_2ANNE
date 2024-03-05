using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageDetector : MonoBehaviour
{

    [SerializeField] ARTrackedImageManager trackedImageManager = null;
    [SerializeField] GameObject cube = null;
    [SerializeField] GameObject trackedCube = null;
    [SerializeField] XRReferenceImageLibrary refer = null;
    void Start()
    {
       
    }

    private void OnEnable()
    {
        Init();
    }
    void Update()
    {
        
    }
    private void Init()
    {
         
        trackedImageManager =GetComponent<ARTrackedImageManager>();
        trackedImageManager.referenceLibrary = refer;
        trackedImageManager.trackedImagesChanged += OnImageDetected;
    }

    void OnImageDetected(ARTrackedImagesChangedEventArgs e)
    {
        foreach (ARTrackedImage item in e.added)
        {
            trackedCube = Instantiate(cube, item.transform.position, Quaternion.identity);
            trackedCube.transform.SetParent(item.transform);
            trackedCube.transform.localPosition =new (0, 0, 0);
            Debug.Log("Image found");

        }

        foreach (ARTrackedImage item in e.updated)
        {
           if( item.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
            item.gameObject.SetActive(true);
            else
            item.gameObject.SetActive(false);
            
        }

        foreach (ARTrackedImage item in e.removed)
        {

        }
    }
}
