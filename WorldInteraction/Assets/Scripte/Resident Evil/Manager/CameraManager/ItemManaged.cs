using System.ComponentModel;
using System.Security.Cryptography;
using UnityEditor.Rendering;
using UnityEngine;

public class ItemManaged : MonoBehaviour, IManagedItem<string, ItemManaged>
{
    [SerializeField, Category("Managed")] 
        string id = "ItemManaged";
   
   // [SerializeField, Category("Camera")]
   // private Camera camera = null;

    public string ItemID => id;
    private void Start() => Register();

    public void Enable()
    {
        Debug.Log("Enable");
    }
    public void Disable()
    {
        Debug.Log("Disable");
    }
    private void Init(){ }
    public void Register() => CameraManager.Instance?.Add(this);
    private void OnDestroy() => CameraManager.Instance?.Remove(this);
}