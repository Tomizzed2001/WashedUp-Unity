using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject chestInventory;

    private UIManager uiManager;
    private InventoryManager inventoryManager;

    private void Start()
    {
        foreach(var gameObj in GameObject.FindGameObjectsWithTag("InventoryManager"))
        {
            inventoryManager = gameObj.GetComponent<InventoryManager>();
        }
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("UIManager"))
        {
            uiManager = gameObj.GetComponent<UIManager>();
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            uiManager.InventoryOpen = true;
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
        //uiManager.ChestOpen = false;
        StartCoroutine(SetChestFalse());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && uiManager.InventoryOpen)
        {
            HideAll();
        }
    }

    private IEnumerator SetChestFalse()
    {
        yield return new WaitForSeconds(0.2f);
        uiManager.InventoryOpen = false;
    }
}
