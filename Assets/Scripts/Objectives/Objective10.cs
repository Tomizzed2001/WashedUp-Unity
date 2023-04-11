using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Collect rope
public class Objective10 : Objective
{
    private void Update()
    {
        bool checkRope = inventoryManager.CheckItem("Rope", 4);

        if (checkRope && !objectiveDone)
        {
            GameManager.Instance.objectivesManager.ShowTools();
            ObjectiveComplete();
        }
    }
}
