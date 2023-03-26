using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject InventoryImage;
    [SerializeField] GameObject InventoryGrid;
    [SerializeField] GameObject Crafting;
    [SerializeField] GameObject Objectives;

    [Header("Button Settings")]
    [SerializeField] bool inventoryOpen = false;

    public void toggleInventory()
    {
        Debug.Log(inventoryOpen);
        if (inventoryOpen)
        {
            InventoryImage.SetActive(false);
            InventoryGrid.SetActive(false);
            Crafting.SetActive(false);
            Objectives.SetActive(false);
            inventoryOpen = false;
        }
        else if (!inventoryOpen)
        {
            InventoryImage.SetActive(true);
            InventoryGrid.SetActive(true);
            Crafting.SetActive(true);
            Objectives.SetActive(true);
            inventoryOpen = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            toggleInventory();
        }
    }
}
