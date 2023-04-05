using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        activeObjectives = new bool[objectiveArray.Length];
        updateObjectives();
    }

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

    public void Objective2()
    {
        objectiveArray[1].objectiveActive = true;
    }

    private void FixedUpdate()
    {
        updateObjectives();
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

    public void SaveObjectives()
    {
        Save.SaveObjectives(activeObjectives);
    }

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
