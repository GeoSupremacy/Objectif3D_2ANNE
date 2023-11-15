using UnityEngine;

public interface IManagedItem <Tkey, TItem> where TItem : MonoBehaviour
{
   Tkey ItemID { get; }
    void Enable();
    void Disable();
    void Register();
}
