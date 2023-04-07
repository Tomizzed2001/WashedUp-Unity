using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildArea : MonoBehaviour
{
    [SerializeField] BuildingScript buildingScript;
    public GameObject uiBuild;
    public GameObject uiSleep;
    public bool buildingComplete;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.inRaid)
        {
            return;
        }
        if (buildingComplete)
        {
            uiSleep.SetActive(true);
        }
        else
        {
            uiBuild.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (buildingComplete)
        {
            uiSleep.SetActive(false);
        }
        else
        {
            uiBuild.SetActive(false);
        }
        
    }

    public void SaveHouse()
    {
        Save.SaveHouse(buildingComplete);
    }

    public void LoadHouse()
    {
        HouseData data = Save.LoadHouse();

        buildingComplete = data.houseBuilt;
        if (buildingComplete)
        {
            buildingScript.LoadHut();
        }
    }
}
