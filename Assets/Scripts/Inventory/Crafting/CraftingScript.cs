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
        bool testRope = InventoryManager.CheckItem("Rope", 2);
        if (testWood && testStone && testRope)
        {
            InventoryManager.removeItem("Wood", 6);
            InventoryManager.removeItem("Stone", 4);
            InventoryManager.removeItem("Rope", 2);
            InventoryManager.AddItem(craftItem);
        }
        else
        {
            CostsTooMuch();
        }
    }

    public void CraftAxe()
    {
        bool testWood = InventoryManager.CheckItem("Wood", 10);
        bool testStone = InventoryManager.CheckItem("Stone", 6);
        bool testRope = InventoryManager.CheckItem("Rope", 2);
        if (testWood && testStone && testRope)
        {
            InventoryManager.removeItem("Wood", 10);
            InventoryManager.removeItem("Stone", 6);
            InventoryManager.removeItem("Rope", 2);
            InventoryManager.AddItem(craftItem);
        }
        else
        {
            CostsTooMuch();
        }
    }

    public void CraftSlingshot()
    {
        bool testWood = InventoryManager.CheckItem("Wood", 8);
        bool testHide = InventoryManager.CheckItem("Hide", 1);
        if (testWood && testHide)
        {
            InventoryManager.removeItem("Wood", 8);
            InventoryManager.removeItem("Hide", 1);
            InventoryManager.AddItem(craftItem);
        }
        else
        {
            CostsTooMuch();
        }
    }

    public void CraftBow()
    {
        bool testWood = InventoryManager.CheckItem("Wood", 10);
        bool testRope = InventoryManager.CheckItem("Rope", 5);
        if (testWood && testRope)
        {
            InventoryManager.removeItem("Wood", 8);
            InventoryManager.removeItem("Rope", 5);
            InventoryManager.AddItem(craftItem);
        }
        else
        {
            CostsTooMuch();
        }
    }

    public void CraftStoneArrow()
    {
        bool testWood = InventoryManager.CheckItem("Wood", 10);
        bool testStone = InventoryManager.CheckItem("Stone", 10);
        if (testWood && testStone)
        {
            InventoryManager.removeItem("Wood", 10);
            InventoryManager.removeItem("Stone", 10);
            for (int i = 0; i < 10; i++)
            {
                InventoryManager.AddItem(craftItem);
            }
        }
        else
        {
            CostsTooMuch();
        }
    }

    public void CraftMetalArrow()
    {
        bool testWood = InventoryManager.CheckItem("Wood", 10);
        bool testMetal = InventoryManager.CheckItem("Metal", 5);
        if (testWood && testMetal)
        {
            InventoryManager.removeItem("Wood", 10);
            InventoryManager.removeItem("Metal", 5);
            for (int i = 0; i < 10; i++)
            {
                InventoryManager.AddItem(craftItem);
            }
        }
        else
        {
            CostsTooMuch();
        }   
    }

    public void CraftPitfall()
    {
        bool testWood = InventoryManager.CheckItem("Wood", 7);
        bool testLeaves = InventoryManager.CheckItem("Leaves", 40);
        if (testWood && testLeaves)
        {
            InventoryManager.removeItem("Wood", 7);
            InventoryManager.removeItem("Leaves", 40);
            InventoryManager.AddItem(craftItem);
        }
        else
        {
            CostsTooMuch();
        }
    }

    public void CraftSapTrap()
    {
        bool testSap = InventoryManager.CheckItem("Sap", 20);
        if (testSap)
        {
            InventoryManager.removeItem("Sap", 20);
            InventoryManager.AddItem(craftItem);
        }
        else
        {
            CostsTooMuch();
        }
    }

    public void CraftSlingTower()
    {
        bool testWood = InventoryManager.CheckItem("Wood", 50);
        bool testStone = InventoryManager.CheckItem("Stone", 60);
        bool testSling = InventoryManager.CheckItem("Slingshot", 1);
        if (testWood && testStone && testSling)
        {
            InventoryManager.removeItem("Wood", 50);
            InventoryManager.removeItem("Stone", 60);
            InventoryManager.removeItem("Slingshot", 1);
            InventoryManager.AddItem(craftItem);
        }
        else
        {
            CostsTooMuch();
        }
    }

    public void CraftArcherTower()
    {
        bool testWood = InventoryManager.CheckItem("Wood", 70);
        bool testStone = InventoryManager.CheckItem("ArrowStone", 50);
        bool testSling = InventoryManager.CheckItem("Bow", 1);
        if (testWood && testStone && testSling)
        {
            InventoryManager.removeItem("Wood", 70);
            InventoryManager.removeItem("ArrowStone", 50);
            InventoryManager.removeItem("Bow", 1);
            InventoryManager.AddItem(craftItem);
        }
        else
        {
            CostsTooMuch();
        }
    }

    public void CostsTooMuch()
    {
        GameManager.Instance.uiManager.NoResources();
    }
}
