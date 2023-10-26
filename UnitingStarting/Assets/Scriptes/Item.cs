using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;
    public int itemQuantity;
    public string itemName;
    public string itemDescription;
    public ItemCategory itemCategory;
    public ItemType itemType;
    public Sprite itemIcon;


    [SerializeField]
    public GameObject itemContainer;
    public enum ItemType
    {
        None,
        Potion,
        CC,
        Distance,
        Food,

    }
   public enum ItemCategory
    {
        Item,
        Sword,
        Axe,
        small,
        medium,
        big,
        heath,
        dammage,
    }
}
