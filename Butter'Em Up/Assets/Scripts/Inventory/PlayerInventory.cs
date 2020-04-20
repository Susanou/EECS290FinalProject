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
                myInventory.Add(thisItem);
                Debug.Log($"Acquired {thisItem.itemName}");
                break;
            case 2:
                myInventory.Add(thisItem); //part of the recipe
                Debug.Log("Acquired recipe fragment");
                break;
            case 3:
                myInventory.Add(thisItem); //item in the recipe
                Debug.Log("Acquired Recipe Component");
                break;
            case 4:
                myInventory.Add(thisItem); //environment objects like keys
                Debug.Log($"Acquired Environment Component {thisItem.itemName}");
                break;
                
        }
    }

    public bool hasKnife()
    {
        return canAttack;
    }
}