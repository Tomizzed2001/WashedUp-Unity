using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private InventoryManager inventoryManager;
    

    [Header("Objective Settings")]
    [SerializeField]
    public bool objectiveActive;

    private void Update()
    {
        bool checkWood = inventoryManager.CheckItem("Wood", 16);
        bool checkStone = inventoryManager.CheckItem("Stone", 10);

        if (checkWood && checkStone)
        {
            objectiveActive = false;
            gameObject.SetActive(false);
        }
    }

}
