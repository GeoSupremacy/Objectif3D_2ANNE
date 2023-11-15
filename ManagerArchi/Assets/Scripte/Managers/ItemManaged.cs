
using UnityEngine;

public class ItemManaged : MonoBehaviour, IManagedItem<string, ItemManaged>
{
    [SerializeField] string id = "TOTO";
    public string ItemID => id;
public void Enable()
{

}
public void Disable()
    {

    }
public void Register()
    {

    }
}
