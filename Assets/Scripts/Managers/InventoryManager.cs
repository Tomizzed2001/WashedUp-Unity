using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("Inventory Components")]
    [SerializeField]
    public GameObject inventoryGrid;
    public GameObject inventoryButton;
    public GameObject inventoryPicture;

    [Header("Inventroy Prefabs")]
    [SerializeField]
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    int selectedSlot = -1;

    [Header("Player assets to update")]
    [SerializeField] AimWeapon playerAim;

    private void Start()
    {
        changeSlot(0);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            changeSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            changeSlot(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            changeSlot(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            changeSlot(5);
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            if (selectedSlot <= 4)
            {
                changeSlot(selectedSlot + 1);
            }
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            if (selectedSlot >= 1)
            {
                changeSlot(selectedSlot - 1);
            }
            
        }

    }

    public void changeSlot(int newSlot)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].UnSelect();
        }

        inventorySlots[newSlot].Select();
        selectedSlot = newSlot;

        if (isSelectedWeapon())
        {
            playerAim.WeaponReady();
        }
        else
        {
            playerAim.WeaponAway();
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemItem = slot.GetComponentInChildren<InventoryItem>();

            if (itemItem != null && itemItem.item == item && itemItem.stackCount <5 && itemItem.item.stackable)
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
    public bool CheckItem(string ItemName, int ItemNum)
    {
        int counter = 0;
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
            if (slotItem == null)
            {
                continue;
            }
            if (slotItem.item != null && slotItem.item.Name == ItemName)
            {
                
                counter += slotItem.stackCount;
                if (counter >= ItemNum)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void removeItem(string ItemName, int ItemNum)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
            if (slotItem == null)
            {
                continue;
            }
            if (slotItem.item != null && slotItem.item.Name == ItemName)
            {
                if (ItemNum > slotItem.stackCount)
                {
                    ItemNum -= slotItem.stackCount;
                    Destroy(slotItem.gameObject);
                    continue;
                }
                if (ItemNum == slotItem.stackCount)
                {
                    Destroy(slotItem.gameObject);
                    return;
                }
                else
                {
                    slotItem.stackCount -= ItemNum;
                    slotItem.UpdateCount();
                    return;
                }
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

    public string getSelectedItemName()
    {
        InventoryItem selectedItem = inventorySlots[selectedSlot].GetComponentInChildren<InventoryItem>();
        if (selectedItem != null)
        {
            return selectedItem.item.Name;
        }
        return null;
    }

    public bool isSelectedTool()
    {
        InventoryItem selectedItem = inventorySlots[selectedSlot].GetComponentInChildren<InventoryItem>();
        if (selectedItem != null)
        {
            return selectedItem.item.isTool;
        }
        return false;
    }

    public bool isSelectedStructure()
    {
        InventoryItem selectedItem = inventorySlots[selectedSlot].GetComponentInChildren<InventoryItem>();
        if (selectedItem != null)
        {
            return selectedItem.item.isStructure;
        }
        return false;
    }

    public bool isSelectedWeapon()
    {
        InventoryItem selectedItem = inventorySlots[selectedSlot].GetComponentInChildren<InventoryItem>();
        if (selectedItem != null)
        {
            return selectedItem.item.isWeapon;
        }
        return false;
    }

    public void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject itemGameObject = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = itemGameObject.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public void SpawnNewStack(Item item, InventorySlot slot, int stackNum)
    {
        if (stackNum == 1)
        {
            SpawnNewItem(item, slot);
            return;
        }
        GameObject itemGameObject = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = itemGameObject.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
        inventoryItem.stackCount = stackNum;
        inventoryItem.UpdateCount();
    }

    public Item CheckSlot(InventorySlot slot)
    {
        InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
        if (slotItem != null)
        {
            return slotItem.item;
        }
        else
        {
            return null;
        }
    }
}
