using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ItemInteracted : MonoBehaviour
{
    [SerializeField, Category("Color")]
    Color defaultcolor;
    [SerializeField, Category("Color")]
    Color changeColor;
    void Start()
    {
        //if (!isValid()) throw new System.NullReferenceException("ItemInteracted => One color is null");
    }
   // private bool isValid() => defaultcolor || changeColor;
    
    public void ResetDefaultColor()
    {
        Debug.Log("ResetDefaultColor");
        gameObject.GetComponent<Renderer>().material.color = defaultcolor;
       
    }
    public void ApplyInteractColor()
    {

        gameObject.GetComponent<Renderer>().material.color = changeColor;
       
    }
    
}
