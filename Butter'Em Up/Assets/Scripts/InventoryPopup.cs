using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryPopup : MonoBehaviour
{
    [SerializeField] public Canvas inventory;
    [SerializeField] public Canvas pause;
    bool inventoryOpen = false;
    bool pauseOpen = false;

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

    bool togglePause()
    {
        pauseOpen = !pauseOpen; //swap state
        pause.gameObject.SetActive(pauseOpen); //activate/deactivate
        return pauseOpen; //new value
    }
}
