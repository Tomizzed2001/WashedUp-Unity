using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [Header("Things to save")]
    [SerializeField] private PlayerController player;
    [SerializeField] private BuildArea house;
    [SerializeField] private Boat boat;

    [Header("Managers")]
    [SerializeField] private TowerManager towerManager;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private ObjectManager objectManager;
    [SerializeField] private ObjectivesManager objectivesManager;

    public void Save()
    {
        Debug.Log("Saving");
        //Save Player related variables
        player.SavePlayer();

        //Save tower related variables
        towerManager.SaveTowers();

        //Save inventory related variables
        itemManager.SaveItems();

        //Save time related variables
        timeManager.SaveTime();

        //Save house related variables
        house.SaveHouse();

        //Save object related variables
        objectManager.SaveObjects();

        //Save objective related variables
        objectivesManager.SaveObjectives();

        //Save boat related variables
        boat.SaveBoat();
    }
}
