using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collect stone
public class ObjectiveTwo : Objective
{
    private void Update()
    {
        bool checkWood = inventoryManager.CheckItem("Stone", 10);

        if (checkWood && !objectiveDone)
        {
            GameManager.Instance.objectivesManager.ShowTools();
            ObjectiveComplete();
        }
    }
}
