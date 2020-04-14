using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Text description;
    [SerializeField] private GameObject equipPrimary;
    [SerializeField] private GameObject equipSecondary;
    [SerializeField] private Attack1 playerAttack;
    public PlayerInventory playerInventory;
    public InventoryItem currentItem;

    public void SetText(string desc)
    {
        description.text = desc;
    }

    private void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);
                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                if (newSlot)
                {
                    newSlot.Setup(playerInventory.myInventory[i], this);
                }
            }
        }
    }

    private void Start()
    {
        MakeInventorySlots();
        SetText("");
    }

    public void SetDesc(InventoryItem targetItem)
    {
        description.text = targetItem.itemDescription;
        currentItem = targetItem;
    }

    public void SetPrimary()
    {
        playerAttack.spread1 = currentItem.itemName;
    }
    public void SetSecondary()
    {
        playerAttack.spread2 = currentItem.itemName;
    }
}
