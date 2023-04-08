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
    [SerializeField] private UIManager uIManager;

    public void BeginBuild()
    {
        
        bool testWood = InventoryManager.CheckItem("Wood", 60);
        bool testStone = InventoryManager.CheckItem("Stone", 30);
        if (testWood && testWood)
        {
            InventoryManager.removeItem("Wood", 60);
            InventoryManager.removeItem("Stone", 30);
            StartCoroutine(TriggerBuild());
        }
        else
        {
            Debug.Log("Not enough resources");
            uIManager.NoResources();
        }
    }

    public void BuildHut()
    {
        playerController.OnBuild();

        // Make the building appear
        Building.SetActive(true);

        // Make the option to build in the UI dissapear
        BuildArea.buildingComplete = true;
        
        Color color = BuildingArea.GetComponent<SpriteRenderer>().color;
        color.a = 0;
        BuildingArea.GetComponent<SpriteRenderer>().color = color;

        // Make sleep button appear
        SleepButton.SetActive(true);
    }

    public void LoadHut()
    {
        Building.SetActive(true);
        uiPopup.SetActive(false);
        Color color = BuildingArea.GetComponent<SpriteRenderer>().color;
        color.a = 0;
        BuildingArea.GetComponent<SpriteRenderer>().color = color;
    }

    private IEnumerator TriggerBuild()
    {
        uIManager.FadeScript.BlackOut();
        yield return new WaitForSeconds(2.5f);
        BuildHut();
        uiPopup.SetActive(false);       
    }
}
