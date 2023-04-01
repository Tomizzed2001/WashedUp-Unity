using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    [Header("Things to load in")]
    [SerializeField] private PlayerController player;
    [SerializeField] private BuildArea house;

    [Header("Managers")]
    [SerializeField] private TowerManager towerManager;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private ObjectManager objectManager;
    [SerializeField] private ObjectivesManager objectivesManager;

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

            //Load time related values
            timeManager.LoadTime();

            //Load house related values
            house.LoadHouse();

            //Load object related values
            objectManager.LoadObjects();

            //Load objective related values
            objectivesManager.LoadObjectives();
        }
    }
}
