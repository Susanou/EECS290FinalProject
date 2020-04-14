using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryPopup : MonoBehaviour
{
    [SerializeField] public Canvas inventory;
    bool inventoryOpen = true; //initializing to true, will sync up on the first use

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryOpen = toggleInventory();
    }

    bool toggleInventory()
    {
        inventory.gameObject.SetActive(inventoryOpen);
        return !inventoryOpen;
    }
}
