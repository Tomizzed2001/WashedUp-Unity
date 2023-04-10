using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Survive
public class ObjectiveSix : Objective
{
    private void Update()
    {
        if (GameManager.Instance.inRaid)
        {
            ObjectiveComplete();
        }
    }
}
