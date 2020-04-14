using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
[System.Serializable]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int type; //0 is butter knife, 1 is spread, 2 is recipe bits, 3 is ingredients, 4 is keys/environment interactables
    public UnityEvent myEvent;

    public void InvokePrimary()
    {

    }

    public void InvokeSecondary()
    {

    }


}
