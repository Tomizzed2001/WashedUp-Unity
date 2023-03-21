using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] GameObject buildRegion;

    private void Update()
    {
        if (inventoryManager.isSelectedStructure())
        {
           buildRegion.SetActive(true);
        }
        else
        {
            buildRegion.SetActive(false);
        }
    }
}
