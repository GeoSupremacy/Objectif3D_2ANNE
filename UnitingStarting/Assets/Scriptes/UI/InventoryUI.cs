using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    InventorySystem inventorySystem;


  //  [SerializeField] InventoryUI inventoryItem = null;
   // [SerializeField] RectTransform inventoryContent = null;

      [SerializeField] GameObject inventoryItem = null;
      [SerializeField] Transform inventoryContent = null;

    // public ItemController[] InventoryItemsController;
    public bool IsValid => inventoryItem && inventoryContent && inventorySystem;

    private void Start()
    {
        ListItems();
    }
    void ClearTransform(Transform _tr)
    {
     foreach(Transform items in _tr)
            Destroy(_tr.gameObject);
        
    }
   public void ListItems()
    {   

        ClearTransform(inventoryContent);
        Debug.Log("ListItems");
        foreach (Item item in inventorySystem.Items)
        {
            GameObject _object = Instantiate(inventoryItem, inventoryContent);
            Text _itemName = _object.transform.Find("Textures/Potion").GetComponent<Text>();
            Image _itemIcon = _object.transform.Find("Textures/Potion").GetComponent<Image>();
                
            _itemName.text = item.itemName;
            _itemIcon.sprite = item.itemIcon;
        }
        
    }
    /*
     *  Text _itemName = _object.transform.Find("Textures/Potion").GetComponent<Text>();
            Image _itemIcon = _object.transform.Find("Textures/Potion").GetComponent<Image>();

            _itemName.text = item.itemName;
            _itemIcon.sprite = item.itemIcon;
     */
    public void SetInventoryItems()
    {
       // inventoryItem = inventoryContent.GetComponentInChildren<ItemController>();
    }
    /*
     Start is called before the first frame update


     for (int i = 0; _tr && _tr.childCount < 10; i++)
            Destroy(_tr.GetChild(i).gameObject);
    void Start()=> GeneratedInventory();

      Debug.Log($"Coucou GeneratedInventory");
        for (int i = 0; IsValid && i < _deals.Length; i++)
        {
            int _index = i;
            InventorySystem _inventory = Instantiate(inventoryItem, inventoryContent);
            _button.Init($"index : {_deals[_index].Title}", ()=>Debug.Log($"Coucou {_deals[_index].SalePrice}"));
           // Instantiate(inventoryItem, inventoryContent);
        }
   */
}//
