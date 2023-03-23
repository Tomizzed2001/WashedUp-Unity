using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject chestInventory;
    //[SerializeField] private GameObject hideAll;

    private InventoryManager inventoryManager;

    private void Start()
    {
        foreach(var gameObj in GameObject.FindGameObjectsWithTag("InventoryManager"))
        {
            inventoryManager = gameObj.GetComponent<InventoryManager>();
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            chestInventory.SetActive(true);
            inventoryManager.inventoryPicture.SetActive(true);
            inventoryManager.inventoryGrid.SetActive(true);
            //hideAll.SetActive(true);
            inventoryManager.inventoryButton.SetActive(false);
        }
    }

    public void HideAll()
    {
        chestInventory.SetActive(false);
        inventoryManager.inventoryPicture.SetActive(false);
        inventoryManager.inventoryGrid.SetActive(false);
        //hideAll.SetActive(false);
        inventoryManager.inventoryButton.SetActive(true);
    }
}
