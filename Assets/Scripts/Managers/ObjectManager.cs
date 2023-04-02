using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] bool[] activeList;

    private void Start()
    {
        
        objects = GameObject.FindGameObjectsWithTag("Object");
        activeList = new bool[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            activeList[i] = objects[i].activeSelf;
        }
    }

    private void updateActiveList()
    {
        activeList = new bool[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            activeList[i] = objects[i].activeSelf;
        }
    }

    public void SaveObjects()
    {
        updateActiveList();
        Save.SaveObjects(activeList);
    }

    public void LoadObjects()
    {
        ObjectData data = Save.LoadObjects();

        for (int i = 0; i<objects.Length; i++)
        {
            if (data.isBroken[i])
            {
                objects[i].SetActive(true);
            }
            else
            {
                objects[i].SetActive(false);
            }
        }
    }



}
