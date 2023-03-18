using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingScript : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public Item craftItem;

    public void CraftPickaxe()
    {
        bool testWood = InventoryManager.CheckItem("Wood", 6);
        bool testStone = InventoryManager.CheckItem("Stone", 4);
        if (testWood && testStone)
        {
            InventoryManager.removeItem("Wood", 6);
            InventoryManager.removeItem("Stone", 4);
            InventoryManager.AddItem(craftItem);
        }
    }

    public void CraftAxe()
    {
        bool testWood = InventoryManager.CheckItem("Wood", 10);
        bool testStone = InventoryManager.CheckItem("Stone", 6);
        if (testWood && testStone)
        {
            InventoryManager.removeItem("Wood", 6);
            InventoryManager.removeItem("Stone", 4);
            InventoryManager.AddItem(craftItem);
        }
    }
}
