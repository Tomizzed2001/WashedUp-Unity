using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private BuildArea buildManager;

    [Header("Objectives")]
    [SerializeField] private GameObject objectiveBorder;
    [SerializeField] private GameObject objectiveTitle;
    [SerializeField] private Objective[] objectiveArray;
    [SerializeField] private bool[] activeObjectives;

    private bool checkForObjectives = false;

    private void Start()
    {
        activeObjectives = new bool[objectiveArray.Length];
        updateObjectives();
    }

    //Updates the active objectives array
    private void updateObjectives()
    {
        for (int i = 0; i < objectiveArray.Length; i++)
        {
            activeObjectives[i] = objectiveArray[i].objectiveActive;
            if (activeObjectives[i] == true)
            {
                objectiveArray[i].gameObject.SetActive(true);
            }
            else
            {
                objectiveArray[i].gameObject.SetActive(false);
            }
        }
    }

    //Checks to see if all objectives are false
    private bool allObjectivesFalse()
    {
        for (int i = 0; i < activeObjectives.Length; i++)
        {
            if (activeObjectives[i])
            {
                return false;
            }
        }
        return true;
    }

    //Check for objective 3
    public void Objective3()
    {
        checkForObjectives = true;
        if (activeObjectives[0] == false && activeObjectives[1] == false)
        {
            checkForObjectives = false;
            objectiveArray[2].objectiveActive = true;
        }
    }

    public void Objective4()
    {
        objectiveArray[3].objectiveActive = true;
    }

    public void Objective5()
    {
        objectiveArray[4].objectiveActive = true;
    }

    public void Objective6()
    {
        objectiveArray[5].objectiveActive = true;
    }

    public void Objective7()
    {
        objectiveArray[6].objectiveActive = true;
    }

    public void Objective8()
    {
        objectiveArray[7].objectiveActive = true;
    }

    public void Objective9()
    {
        objectiveArray[8].objectiveActive = true;
    }

    //Calls update every frame to check if the objective border is needed
    private void FixedUpdate()
    {
        updateObjectives();
        if (checkForObjectives)
        {
            Objective3();
        }
        if (allObjectivesFalse())
        {
            objectiveBorder.SetActive(false);
            objectiveTitle.SetActive(false);
        }
        else
        {
            objectiveBorder.SetActive(true);
            objectiveTitle.SetActive(true);
        }
    }

    //Saves the active objectives
    public void SaveObjectives()
    {
        Save.SaveObjectives(activeObjectives);
    }

    //Loads in active objectives
    public void LoadObjectives()
    {
        ObjectiveData data = Save.LoadObjectives();

        activeObjectives = data.activeObjectives;

        for (int i = 0; i < activeObjectives.Length; i++)
        {
            objectiveArray[i].objectiveActive = activeObjectives[i];
        }
    }
}
