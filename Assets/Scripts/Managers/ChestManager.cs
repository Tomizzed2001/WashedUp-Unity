using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private InventoryManager inventoryManager;

    [Header("Slot and Item")]
    [SerializeField] private InventorySlot slot1;
    [SerializeField] private Item item1;

    public void Start()
    {
        if (!StartScript.toLoad)
        {
            inventoryManager.SpawnNewItem(item1, slot1);            
        }
    }
}
