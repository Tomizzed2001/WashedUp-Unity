using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixBoat : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Boat to fix")]
    [SerializeField] Boat boat;

    [Header("Managers")]
    [SerializeField] UIManager uiManager;
    [SerializeField] InventoryManager inventoryManager;

    [Header("Boat Images")]
    [SerializeField] GameObject[] buildCosts;

    //Show the cost of the build upon hovering over the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (boat.boatFixed)
        {
            return;
        }
        buildCosts[boat.boatTier].SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (boat.boatFixed)
        {
            return;
        }
        buildCosts[boat.boatTier].SetActive(false);
    }


    // Upgrade the boat to the next tier image whilst triggering a fade animation
    public void fixTheBoat()
    {

        //Check differing cost depending on the boat tier
        bool check1 = false;
        bool check2 = false;
        bool check3 = false;
        if (boat.boatTier == 0)
        {
            check1 = inventoryManager.CheckItem("Wood", 80);
            check2 = inventoryManager.CheckItem("Rope", 6);
            check3 = inventoryManager.CheckItem("Sap", 20);
            if (check1 && check2 && check3)
            {
                inventoryManager.removeItem("Wood", 80);
                inventoryManager.removeItem("Rope", 6);
                inventoryManager.removeItem("Sap", 20);
            }
        }
        else if (boat.boatTier == 1)
        {
            check1 = inventoryManager.CheckItem("Wood", 150);
            check2 = inventoryManager.CheckItem("Nail", 80);
            check3 = inventoryManager.CheckItem("Sap", 40);
            if (check1 && check2 && check3)
            {
                inventoryManager.removeItem("Wood", 150);
                inventoryManager.removeItem("Nail", 80);
                inventoryManager.removeItem("Sap", 40);
            }
        }
        else if (boat.boatTier == 2)
        {
            check1 = inventoryManager.CheckItem("Wood", 200);
            check2 = inventoryManager.CheckItem("Nail", 100);
            check3 = inventoryManager.CheckItem("Rope", 50);
            if (check1 && check2 && check3)
            {
                inventoryManager.removeItem("Wood", 200);
                inventoryManager.removeItem("Nail", 100);
                inventoryManager.removeItem("Rope", 50);
            }
        }
        else if (boat.boatTier == 3)
        {
            check1 = inventoryManager.CheckItem("Rope", 40);
            check2 = inventoryManager.CheckItem("Nail", 100);
            check3 = inventoryManager.CheckItem("Hide", 80);
            if (check1 && check2 && check3)
            {
                inventoryManager.removeItem("Rope", 40);
                inventoryManager.removeItem("Nail", 100);
                inventoryManager.removeItem("Hide", 80);
            }
        }
        else if (boat.boatTier == 4)
        {
            check1 = inventoryManager.CheckItem("Metal", 100);
            check2 = inventoryManager.CheckItem("Hide", 100);
            check3 = inventoryManager.CheckItem("Rope", 100);
            if (check1 && check2 && check3)
            {
                inventoryManager.removeItem("Metal", 100);
                inventoryManager.removeItem("Hide", 100);
                inventoryManager.removeItem("Rope", 100);
            }
        }

        //Check if requirements are met and trigger build if so else show not enough
        if (check1 && check2 && check3)
        {
            StartCoroutine(TriggerBuild());
        }
        else
        {
            uiManager.NoResources();
        }
    }

    // End the game by sailing off the island
    public void setSail()
    {
        GameManager.Instance.GameWin(false);
    }


    //Coroutine that triggers the fade animnation and upgrades the boat at its darkest point
    private IEnumerator TriggerBuild()
    {
        uiManager.FadeScript.BlackOut();
        yield return new WaitForSeconds(2.5f);
        boat.fixedToday = true;
        boat.IncreaseTier();
        gameObject.SetActive(false);
    }
}
