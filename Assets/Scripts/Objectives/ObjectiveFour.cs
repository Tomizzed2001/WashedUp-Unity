using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveFour : Objective
{
    [SerializeField] private BuildArea buildArea;

    private void Update()
    {
        if (buildArea.buildingComplete)
        {
            objectiveActive = false;
            gameObject.SetActive(false);
            GameManager.Instance.objectivesManager.Objective5();
        }
    }
}
