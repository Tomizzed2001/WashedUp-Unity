using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemItem = slot.GetComponentInChildren<InventoryItem>();

            if (itemItem != null && itemItem.item == item && itemItem.stackCount <5)
            {
                itemItem.stackCount++;
                itemItem.UpdateCount();
                return;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemItem = slot.GetComponentInChildren<InventoryItem>();
            
            if (itemItem == null )
            {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    public bool checkInventoryFull()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventoryItem slotCheck = inventorySlots[i].GetComponentInChildren<InventoryItem>();
            if (slotCheck == null)
            {
                return false;
            }
        }
        return true;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject itemGameObject = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = itemGameObject.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}
