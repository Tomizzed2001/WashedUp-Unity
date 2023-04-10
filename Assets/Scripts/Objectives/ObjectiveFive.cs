using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defences
public class ObjectiveFive : Objective
{
    [Header("Tower Manager")]
    [SerializeField] TowerManager towerManager;

    private void Update()
    {
        if (towerManager.defencesPlaced == 4)
        {
            GameManager.Instance.objectivesManager.ShowSurvive();
            ObjectiveComplete();
        }
    }
}
