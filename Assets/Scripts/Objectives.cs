using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private InventoryManager inventoryManager;

    [Header("Objectives")]
    public GameObject objectiveOne;

    public void Objective1() // Objective 1 is to collect 16 wood and 10 stone
    {
        bool checkWood = inventoryManager.CheckItem("Wood", 16);
        bool checkStone = inventoryManager.CheckItem("Stone", 10);

        if (checkWood && checkStone)
        {
            objectiveOne.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Objective1();
    }
}
