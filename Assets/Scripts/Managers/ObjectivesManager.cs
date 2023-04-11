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
    [SerializeField] private bool[] doneObjectives;

    [Header("Objective related objects")]
    [SerializeField] private GameObject wreckage;

    private bool checkForObjectives = false;

    private void Start()
    {
        activeObjectives = new bool[objectiveArray.Length];
        doneObjectives = new bool[objectiveArray.Length];
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

    private void checkDoneObjectives()
    {
        for (int i = 0; i < objectiveArray.Length; i++)
        {
            doneObjectives[i] = objectiveArray[i].objectiveDone;
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
    public void ShowTools()
    {
        checkForObjectives = true;
        if (objectiveArray[0].objectiveDone && objectiveArray[1].objectiveDone && objectiveArray[2].objectiveDone)
        {
            checkForObjectives = false;
            objectiveArray[3].objectiveActive = true;
            objectiveArray[10].objectiveActive = true;
        }
    }

    public void ShowShelter()
    {
        objectiveArray[4].objectiveActive = true;
    }

    public void ShowFix()
    {
        objectiveArray[5].objectiveActive = true;
    }

    public void ShowDefences()
    {
        objectiveArray[6].objectiveActive = true;
    }

    public void ShowSurvive()
    {
        objectiveArray[7].objectiveActive = true;
    }

    public void ShowExplore()
    {
        ShowWreckage();
        objectiveArray[8].objectiveActive = true;
    }

    public void ShowSail()
    {
        objectiveArray[9].objectiveActive = true;
    }

    public void ShowWreckage()
    {
        wreckage.SetActive(true);
        GameManager.Instance.wreckageActive = true;
    }

    //Calls update every frame to check if the objective border is needed
    private void FixedUpdate()
    {
        updateObjectives();
        if (checkForObjectives)
        {
            ShowTools();
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
        checkDoneObjectives();
        Save.SaveObjectives(activeObjectives, doneObjectives);
    }

    //Loads in active objectives
    public void LoadObjectives()
    {
        ObjectiveData data = Save.LoadObjectives();

        activeObjectives = data.activeObjectives;
        doneObjectives = data.doneObjectives;

        for (int i = 0; i < objectiveArray.Length; i++)
        {
            objectiveArray[i].objectiveDone = doneObjectives[i];
        }
        for (int i = 0; i < activeObjectives.Length; i++)
        {
            objectiveArray[i].objectiveActive = activeObjectives[i];
        }
        //updateObjectives();
    }
}
