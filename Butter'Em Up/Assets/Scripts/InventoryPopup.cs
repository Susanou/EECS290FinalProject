using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryPopup : MonoBehaviour
{
    [SerializeField] public Canvas inventory;
    bool inventoryOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryOpen = toggleInventory();
    }

    bool toggleInventory()
    {
        inventoryOpen = !inventoryOpen; //swap state
        inventory.gameObject.SetActive(inventoryOpen); //activate/deactivate
        return inventoryOpen; //new value
    }
}
