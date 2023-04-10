using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Build Shelter
public class ObjectiveFour : Objective
{
    [SerializeField] private BuildArea buildArea;

    private void Update()
    {
        if (buildArea.buildingComplete)
        {
            GameManager.Instance.objectivesManager.ShowFix();
            GameManager.Instance.objectivesManager.ShowDefences();
            ObjectiveComplete();
        }
    }
}
