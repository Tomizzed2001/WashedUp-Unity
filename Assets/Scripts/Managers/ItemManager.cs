using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("All items list")]
    public Item[] AllItems;

    [Header("Managers")]
    [SerializeField] private InventoryManager inventoryManager;

    [Header("Value Lists")]
    [SerializeField] private InventorySlot[] allSlots;
    [SerializeField] private int[] stackNums;
    [SerializeField] private string[] itemNames;

    private void Start()
    {
        allSlots = inventoryManager.allSlots;
        stackNums = new int[allSlots.Length];
        itemNames = new string[allSlots.Length];
    }

    public void SaveItems()
    {
        updateArrays();
        Save.SaveInventory(stackNums, itemNames);
    }

    public void LoadItems()
    {
        InventoryData data = Save.LoadInventory();

        for (int i = 0; i < allSlots.Length; i++)
        {
            Item item = FindItem(data.itemNames[i]);
            placeItem(allSlots[i], item, data.stackNums[i]);
        }
    }

    public void placeItem(InventorySlot slot, Item item, int stackCount)
    {
        if (item == null)
        {
            return;
        }
        else
        {
            inventoryManager.SpawnNewStack(item, slot, stackCount);
        }
    }

    public void updateArrays()
    {
        stackNums = new int[allSlots.Length];
        itemNames = new string[allSlots.Length];
        for (int i = 0; i < allSlots.Length; i++)
        {
            //Get new inventory slot
            InventoryItem slotItem = allSlots[i].GetComponentInChildren<InventoryItem>();

            //Update stack count array
            if (slotItem != null)
            {
                stackNums[i] = slotItem.stackCount;
            }
            else
            {
                stackNums[i] = 0;
            }

            //Update names array
            Item item = GetItem(allSlots[i]);
            string name = GetItemName(item);
            if (name != null)
            {
                itemNames[i] = name;
            }
            else
            {
                itemNames[i] = null;
            }
        }
    }

    public string GetItemName(Item item)
    {
        if (item == null)
        {
            return null;
        }
        else
        {
            return item.name;
        }
    }

    public Item GetItem(InventorySlot slot)
    {
        Item storeItem = inventoryManager.CheckSlot(slot);
        return storeItem;
    }


    public Item FindItem(string name)
    {
        if (name == null)
        {
            return null;
        }
        for(int i = 0; i < AllItems.Length; i++)
        {
            if(name == AllItems[i].name)
            {
                return AllItems[i];
            }
        }
        return null;
    }
}
