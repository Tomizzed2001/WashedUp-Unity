using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [Header("Things to save")]
    [SerializeField] private PlayerController player;

    [Header("Managers")]
    [SerializeField] private TowerManager towerManager;
    [SerializeField] private ItemManager itemManager;

    public void Save()
    {
        //Save Player related variables
        player.SavePlayer();

        //Save tower related variables
        towerManager.SaveTowers();

        //Save inventory related variables
        itemManager.SaveItems();

    }
}
