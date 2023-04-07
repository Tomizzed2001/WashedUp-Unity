using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveEight : Objective
{
    [SerializeField] ChestManager chestManager;

    private void Update()
    {
        if (GameManager.Instance.chestOpened)
        {
            objectiveActive = false;
            gameObject.SetActive(false);
        }
    }
}
