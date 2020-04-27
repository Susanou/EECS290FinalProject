using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();
    [System.NonSerialized]
    public bool canAttack = false;
    public string currentPrimary;
    public string currentSecondary;

    public void addItem(InventoryItem thisItem)
    {
        Debug.Log($"Added item {thisItem.itemName}, type {thisItem.type}");
        switch (thisItem.type)
        {
            case 0:
                //myInventory.Add(thisItem); // we don't add the butter knife since it can't be equipped
                canAttack = true; //the butter knife enables attacking
                Debug.Log("Acquired Butter Knife");
                break;
            case 1:
                myInventory.Add(thisItem); //spreads
                Debug.Log($"Acquired {thisItem.itemName}");
                break;
            case 2:
                if (!myInventory.Contains(thisItem))
                {
                    myInventory.Add(thisItem); //recipe
                }
                Debug.Log("Acquired recipe fragment");
                break;
            case 3:
                if (!myInventory.Contains(thisItem))
                {
                    myInventory.Add(thisItem); //ingredient
                }
                Debug.Log("Acquired Recipe Component");
                break;                
        }
    }

    public bool hasKnife()
    {
        return canAttack;
    }
}