using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
    public int[] stackNums;
    public string[] itemNames;

    public InventoryData(int[] nums, string[] names)
    {
        stackNums = nums; 
        itemNames = names;
    }
}
