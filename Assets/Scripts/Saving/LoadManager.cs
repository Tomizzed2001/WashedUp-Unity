using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    [Header("Things to load in")]
    [SerializeField] PlayerController player;
    [SerializeField] TowerManager towerManager;
    [SerializeField] ItemManager itemManager;

    private void Start()
    {
        if (StartScript.toLoad)
        {
            //Load player related values
            player.LoadPlayer();

            //Load tower related values
            towerManager.LoadTowers();

            //Load inventory related values
            itemManager.LoadItems();

        }
    }
}
