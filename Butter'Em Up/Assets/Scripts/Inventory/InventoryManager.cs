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
    public PlayerInventory playerInventory;

    public void SetText(string desc)
    {
        description.text = desc;
    }

    private void Start()
    {
        SetText("");
    }
}
