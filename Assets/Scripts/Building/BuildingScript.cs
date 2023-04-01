using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingScript : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public GameObject Button;
    public GameObject SleepButton;
    public GameObject Building;
    public GameObject uiPopup;
    public GameObject BuildingArea;

    public BuildArea BuildArea;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private ObjectivesManager objectivesManager;

    public void BuildHut()
    {
        // Remove and check resources in inventory
        bool testWood = InventoryManager.CheckItem("Wood", 60);
        bool testStone = InventoryManager.CheckItem("Stone", 30);
        if (testWood && testStone)
        {
            playerController.OnBuild();

            InventoryManager.removeItem("Wood", 60);
            InventoryManager.removeItem("Stone", 30);

            // Make the building appear
            Building.SetActive(true);

            // Make the option to build in the UI dissapear
            BuildArea.buildingComplete = true;
            uiPopup.SetActive(false);
            Color color = BuildingArea.GetComponent<SpriteRenderer>().color;
            color.a = 0;
            BuildingArea.GetComponent<SpriteRenderer>().color = color;

            // Start the next objective
            objectivesManager.Objective2();

            // Make sleep button appear
            SleepButton.SetActive(true);
        } 
        else
        {
            Debug.Log("Not enough resources");
        }
    }

    public void LoadHut()
    {
        Building.SetActive(true);
        uiPopup.SetActive(false);
        Color color = BuildingArea.GetComponent<SpriteRenderer>().color;
        color.a = 0;
        BuildingArea.GetComponent<SpriteRenderer>().color = color;
    }

}
