using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildArea : MonoBehaviour
{
    public GameObject uiBuild;
    public GameObject uiSleep;
    public bool buildingComplete;

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
}
