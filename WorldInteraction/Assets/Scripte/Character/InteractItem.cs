using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public static class Extension
{
    public static GameObject GameObject(this RaycastHit _ray)
    {
        return _ray.transform.gameObject;
    }
   /* public static MonoBehaviour GetComponentA<T>(this RaycastHit _ray)
    {
        return _ray.GameObject().GetComponent<T>();
    }
    */
}

public class InteractItem : MonoBehaviour
{
    #region Settings
    [SerializeField, Category("Interact Layer")]// MonoBehaviour[] interactLayer;
    private LayerMask hitLayer;
    [SerializeField, Category("Interact Layer"), Range(0, 100)] float range = 3;
    [SerializeField, Category("Interact Layer"), Range(0, 100)] float height = 1.6f;
    [SerializeField, Category("Interact Layer"), Range(0, 100)] float fall = 2;
    [SerializeField, Category("Interact Layer")] ItemInteracted currentItem = null;
    [SerializeField, Category("Interact Layer")] ItemInteracted detectedItem = null;
    
    bool canGrabItem = false, isHit =false, hasGrabObject =false, hasDrop =false;
   
    RaycastHit result;
   
  
    #endregion
    private void Update() => DetectedObject();
    void DetectedObject()
    {
        Vector3 _start = transform.position + new Vector3(0, height, 0),
        _to = transform.forward - new Vector3(0, fall, 0);

        isHit = Physics.Raycast(new(_start, _to), out  result, range, hitLayer);
        
        canGrabItem = isHit && result.distance < 1.6f;
       DetectedObjectFeedback(result.GameObject());
    }
    void DetectedObjectFeedback(GameObject _item)
    {

        if (canGrabItem)
            detectedItem = _item.GameObject().GetComponent<ItemInteracted>();
        else
            detectedItem = null;
       // else
       // {
       //     detectedItem.ResetDefaultColor();
       // }

    }
    public void GrabObject()
    {
        
        if (currentItem)
            return;
        if (canGrabItem)
        {
            if (hasDrop)
            {
                hasDrop = false;
                return;
            }
            Debug.Log("GRAB");
            currentItem = result.GameObject().GetComponent<ItemInteracted>();
          
            currentItem.ApplyInteractColor();
            //currentItem.SetActorEnableCollision(false);
            // currentItem.AttachToActor(GetOwner(), FAttachmentTransformRules::KeepWorldTransform);
            currentItem.transform.SetParent(transform, true);
            // detectedItem = result.GameObject().GetComponent<ItemInteracted>(); ;
            currentItem.ApplyInteractColor();
            hasGrabObject = true;
        }

    }
    public void DropObject()
    {
        if(!hasGrabObject || !currentItem) return;
       
        currentItem.transform.SetParent(null);
        //currentItem->SetActorEnableCollision(true);
        currentItem.ResetDefaultColor();
        currentItem = null;
        hasGrabObject=false;
        hasDrop = true;
    }

    private void OnDrawGizmos() => DrawDebug();
    void DrawDebug()
    {

        Vector3 _start = transform.position + new Vector3(0, height, 0),
       _to = transform.forward - new Vector3(0, fall, 0);

        bool _isHit = Physics.Raycast(new(_start, _to), out RaycastHit result, range, hitLayer);
       
        if (!_isHit && result.distance < 1)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_start, _to * range);
        }
        else {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(_start, _to * range);
        }
        
    }
}//