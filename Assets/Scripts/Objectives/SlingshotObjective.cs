using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotObjective : Objective
{
    private void Update()
    {
        bool checkSling = inventoryManager.CheckItem("Slingshot", 1);

        if (checkSling)
        {
            ObjectiveComplete();
        }
    }
}
