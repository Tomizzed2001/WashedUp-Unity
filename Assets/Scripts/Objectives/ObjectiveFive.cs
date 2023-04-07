using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveFive : Objective
{
    [Header("Tower Manager")]
    [SerializeField] TowerManager towerManager;

    private void Update()
    {
        if (towerManager.defencesPlaced == 5)
        {
            objectiveActive = false;
            gameObject.SetActive(false);
            GameManager.Instance.objectivesManager.Objective6();
        }
    }
}
