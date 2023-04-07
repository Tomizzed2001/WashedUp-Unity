using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSix : Objective
{
    private void Update()
    {
        if (GameManager.Instance.inRaid)
        {
            objectiveActive = false;
            gameObject.SetActive(false);
        }
    }
}
