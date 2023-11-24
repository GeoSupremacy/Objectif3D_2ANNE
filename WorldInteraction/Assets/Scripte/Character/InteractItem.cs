using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;



public class InteractItem : MonoBehaviour
{
    [SerializeField, Category("Interact Layer")]// MonoBehaviour[] interactLayer;
    private LayerMask hitLayer;
    [SerializeField, Category("Interact Layer"), Range(0, 100)] float range = 3;
    [SerializeField, Category("Interact Layer"), Range(0, 100)] float height = 1.6f;
    [SerializeField, Category("Interact Layer"), Range(0, 100)] float fall = 2;
    [SerializeField, Category("Interact Layer")] ItemInteracted currentItem = null;
    [SerializeField, Category("Interact Layer")] ItemInteracted detectedItem = null;
    bool canGrabItem = false;
    RaycastHit result;
    bool isHit;
    private void Update() => DetectedObject();
    void DetectedObject()
    {
        Vector3 _start = transform.position + new Vector3(0, height, 0),
        _to = transform.forward - new Vector3(0, fall, 0);

        isHit = Physics.Raycast(new(_start, _to), out  result, range, hitLayer);

        canGrabItem = isHit && result.distance < 1;
       // DetectedObjectFeedback(result.Type());
    }
    void DetectedObjectFeedback(ItemInteracted _item)
    {
       
        if (canGrabItem)
        {

            if (detectedItem)
                detectedItem.ResetDefaultColor();
            detectedItem = _item.gameObject;
            detectedItem.ApplyInteractColor();
        }
        else
        {
            detectedItem.ResetDefaultColor();
        }
        
    }
    public void GrabObject()
    {
        /*
        if (currentItem)
            return;
        if (canGrabItem)
        {
            PRINT_STRING("GRAB");
            currentItem = Cast<AInteractItem>(result.GetActor());
            currentItem->ApplyInteractColor();
            currentItem->SetActorEnableCollision(false);
            currentItem->AttachToActor(GetOwner(), FAttachmentTransformRules::KeepWorldTransform);
            detectedItem = Cast<AInteractItem>(result.GetActor());
            detectedItem->ApplyInteractColor();
        }
        */
    }
    public void DropObject()
    {
        /*
        if (currentItem)
            return;
        currentItem->DetachFromActor(FDetachmentTransformRules::KeepWorldTransform);
        currentItem->SetActorEnableCollision(true);
        currentItem->ResetDefaultColor();
        currentItem = nullptr;
        */
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