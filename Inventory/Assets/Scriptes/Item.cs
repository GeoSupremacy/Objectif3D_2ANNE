using UnityEngine;

//[CreateAssetMenu(fileName ="New Item", menuName ="Item/Create new Item")]
public class Item //:ScriptableObject
{
    public string ItemName;
    public string ItemDescription;
    public int ItemQuantity;
    public Sprite ItemIcon;
    public Item(string _ItemName, int _itemCount)
    {
        ItemName = _ItemName;
        ItemQuantity = _itemCount;
       //ItemIcon = _sprite;
    }
   
}
