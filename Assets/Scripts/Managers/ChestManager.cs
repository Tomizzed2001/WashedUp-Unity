using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private InventoryManager inventoryManager;

    [Header("Woods Chest")]
    [SerializeField] public Chest woodsChest;
    [Header("Slot and Item 1")]
    [SerializeField] private InventorySlot slot1;
    [SerializeField] private Item item1;
    [SerializeField] private int numberToSpawn1;

    [Header("Slot and Item 2")]
    [SerializeField] private InventorySlot slot2;
    [SerializeField] private Item item2;
    [SerializeField] private int numberToSpawn2;

    [Header("Wreckage 1 Chest")]
    [SerializeField] public Chest wreckageOneChest;
    [Header("Slot and Item 3")]
    [SerializeField] private InventorySlot slot3;
    [SerializeField] private Item item3;
    [SerializeField] private int numberToSpawn3;

    [Header("Slot and Item 4")]
    [SerializeField] private InventorySlot slot4;
    [SerializeField] private Item item4;
    [SerializeField] private int numberToSpawn4;

    [Header("Slot and Item 5")]
    [SerializeField] private InventorySlot slot5;
    [SerializeField] private Item item5;
    [SerializeField] private int numberToSpawn5;

    [Header("House Chest")]
    [SerializeField] public Chest houseChest;

    public void Start()
    {
        if (!StartScript.toLoad)
        {
            inventoryManager.SpawnNewStack(item1, slot1, numberToSpawn1);
            inventoryManager.SpawnNewStack(item2, slot2, numberToSpawn2);
            inventoryManager.SpawnNewStack(item3, slot3, numberToSpawn3);
            inventoryManager.SpawnNewStack(item4, slot4, numberToSpawn4);
            inventoryManager.SpawnNewStack(item5, slot5, numberToSpawn5);
        }
    }
}
