using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private ItemManager itemManager;

    [SerializeField] private InventorySlot[] allSlots;
    [SerializeField] private List<int> stackNums;
    [SerializeField] private List<string> itemNames;

    private void Start()
    {
        stackNums = new List<int>();
        itemNames = new List<string>();
        allSlots = inventoryManager.inventorySlots;
    }

    public void SpawnAllItems()
    {
        for (int i = 0; i < allSlots.Length; i++)
        {
            Item item = itemManager.FindItem(itemNames[i]);
            Spawn(allSlots[i], item, stackNums[i]);
        }
    }

    public void Spawn(InventorySlot slot2spawn, Item item2spawn, int stackcount)
    {
        if (item2spawn == null)
        {
            Debug.Log("Nothing to spawn");
            return;
        }
        else
        {
            Debug.Log("Spawning " + item2spawn.name);
            inventoryManager.SpawnNewStack(item2spawn, slot2spawn, stackcount);
        }
        
    }

    public void GetAllItems()
    {
        stackNums.Clear();
        itemNames.Clear();
        for (int i = 0; i < allSlots.Length; i++)
        {
            InventoryItem slotItem = allSlots[i].GetComponentInChildren<InventoryItem>();
            if (slotItem != null)
            {
                stackNums.Add(slotItem.stackCount);
            }
            else
            {
                stackNums.Add(0);
            }
            GetItem(allSlots[i]);
        }
    }

    public void GetItemName(Item item)
    {
        if (item == null)
        {
            itemNames.Add(null);
        }
        else
        {
            itemNames.Add(item.name);
        }
    }

    public void GetItem(InventorySlot slot2get)
    {
        Item storeItem = inventoryManager.CheckSlot(slot2get);
        GetItemName(storeItem);
    }
}
