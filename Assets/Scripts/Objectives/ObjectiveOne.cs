using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

// Collect wood
public class ObjectiveOne : Objective
{
    private void Update()
    {
        bool checkWood = inventoryManager.CheckItem("Wood", 16);

        if (checkWood && !objectiveDone)
        {
            GameManager.Instance.objectivesManager.ShowTools();
            ObjectiveComplete();
        }
    }
}
