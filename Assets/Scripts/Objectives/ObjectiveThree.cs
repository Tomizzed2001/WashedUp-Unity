using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveThree : Objective
{
    private void Update()
    {
        bool checkAxe = inventoryManager.CheckItem("Axe", 1);
        bool checkPick = inventoryManager.CheckItem("Pickaxe", 1);

        if (checkAxe && checkPick)
        {
            objectiveActive = false;
            gameObject.SetActive(false);
            GameManager.Instance.objectivesManager.Objective4();
            GameManager.Instance.objectivesManager.Objective7();
        }
    }
}
