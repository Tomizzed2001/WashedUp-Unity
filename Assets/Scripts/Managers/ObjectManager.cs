using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] bool[] activeList;

    [SerializeField] private int rarity;

    private void Start()
    {
        
        objects = GameObject.FindGameObjectsWithTag("Object");
        activeList = new bool[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].GetComponent<Breakable>().DayToSpawn > 1 )
            {
                objects[i].SetActive(false);
            }
            activeList[i] = objects[i].activeSelf;
        }
    }

    private void UpdateActiveList()
    {
        activeList = new bool[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            activeList[i] = objects[i].activeSelf;
        }
    }

    public void SaveObjects()
    {
        UpdateActiveList();
        Save.SaveObjects(activeList);
    }
    /*
    public void objectAppear(int day)
    {
        UpdateActiveList();
        for (int i = 0; i < objects.Length; i++)
        {
            Breakable script = objects[i].GetComponent<Breakable>();
            if (activeList[i] == false && script.DayToSpawn <= day)
            {
                int respawn = Random.Range(0, 10);
                if (respawn >= 5)
                {
                    objects[i].SetActive(true);
                    script.resetHealth();
                }
            }
        }
        UpdateActiveList();
    }
    */
    public void ObjectRespawn(int day)
    {
        UpdateActiveList();
        for (int i = 0; i < objects.Length; i++)
        {
            Breakable script = objects[i].GetComponent<Breakable>();
            if (script.canRespawn)
            {
                if (activeList[i] == false && script.DayToSpawn <= day)
                {
                    float respawn = Random.Range(0f, 1f);
                    if (respawn <= script.respawnChance)
                    {
                        objects[i].SetActive(true);
                        script.resetHealth();
                    }
                }
            }
        }
    }

    public void LoadObjects()
    {
        ObjectData data = Save.LoadObjects();

        for (int i = 0; i<objects.Length; i++)
        {
            objects[i].SetActive(data.isBroken[i]);
        }
    }



}
