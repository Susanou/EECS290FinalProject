using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Text itemName;
    [SerializeField] private Image itemImage;
    // Start is called before the first frame update
    public InventoryItem thisItem;
    public InventoryManager thisManager;
    public void Setup(InventoryItem thisItem, InventoryManager manager)
    {
        this.thisItem = thisItem;
        this.thisManager = manager;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            this.itemName.text = thisItem.itemName;
        }
    }

    public void ClickedOn()
    {
        if (thisItem)
        {
            thisManager.SetDesc(thisItem.itemDescription);
        }
    }
}
