using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectiveOne : Objective
{
    private void Update()
    {
        bool checkWood = inventoryManager.CheckItem("Wood", 16);

        if (checkWood)
        {
            objectiveActive = false;
            gameObject.SetActive(false);
            GameManager.Instance.objectivesManager.Objective3();
        }
    }
}
