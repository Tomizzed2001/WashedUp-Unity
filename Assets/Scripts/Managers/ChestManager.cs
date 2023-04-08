using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private InventoryManager inventoryManager;

    [Header("Slot and Item 1")]
    [SerializeField] private InventorySlot slot1;
    [SerializeField] private Item item1;
    [Header("Slot and Item 2")]
    [SerializeField] private InventorySlot slot2;
    [SerializeField] private Item item2;
    [Header("Slot and Item 3")]
    [SerializeField] private InventorySlot slot3;
    [SerializeField] private Item item3;
    [Header("Slot and Item 4")]
    [SerializeField] private InventorySlot slot4;
    [SerializeField] private Item item4;

    public void Start()
    {
        if (!StartScript.toLoad)
        {
            inventoryManager.SpawnNewItem(item1, slot1);   
            inventoryManager.SpawnNewItem(item2, slot2);
            inventoryManager.SpawnNewItem(item3, slot3);
            inventoryManager.SpawnNewItem(item4, slot4);
        }
    }
}
