using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basic tools
public class ObjectiveThree : Objective
{
    private void Update()
    {
        bool checkAxe = inventoryManager.CheckItem("Axe", 1);
        bool checkPick = inventoryManager.CheckItem("Pickaxe", 1);

        if (checkAxe && checkPick)
        {
            GameManager.Instance.objectivesManager.ShowShelter();
            ObjectiveComplete();
        }
    }
}
