using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTwo : Objective
{
    private void Update()
    {
        bool checkWood = inventoryManager.CheckItem("Stone", 10);

        if (checkWood)
        {
            objectiveActive = false;
            gameObject.SetActive(false);
            GameManager.Instance.objectivesManager.Objective3();
        }
    }
}
