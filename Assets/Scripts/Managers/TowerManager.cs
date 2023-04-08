using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] GameObject[] Defences;
    [SerializeField] Transform PlacementZone;
    [SerializeField] InventoryManager inventoryManager;

    [HideInInspector] public int defencesPlaced = 0;

    public void Build(string towerName)
    {
        for (int i = 0; i < Defences.Length; i++)
        {
            if (towerName == Defences[i].name)
            {
                inventoryManager.removeItem(towerName, 1);
                GameObject newTower = Instantiate(Defences[i], PlacementZone.position, Quaternion.identity);
            }
        }
    }

    public void LoadBuild(string towerName, Vector3 pos)
    {
        for (int i = 0; i < Defences.Length; i++)
        {
            if (towerName == Defences[i].name)
            {
                GameObject newDefence = Instantiate(Defences[i], pos, Quaternion.identity);
            }
        }
    }

    public void SaveTowers()
    {
        Save.SaveTower(GameObject.FindObjectsOfType<Tower>());
        Save.SaveTraps(GameObject.FindObjectsOfType<Trap>());
    }

    public void LoadTowers()
    {
        AllTowerData data = Save.LoadTower();

        for (int i = 0; i < data.towerDatas.Length; i++)
        {
            Vector3 pos;
            pos.x = data.towerDatas[i].position[0];
            pos.y = data.towerDatas[i].position[1];
            pos.z = data.towerDatas[i].position[2];

            LoadBuild(data.towerDatas[i].towerName, pos);
        }

        AllTrapData dataTraps = Save.LoadTraps();

        for (int i = 0; i < dataTraps.trapDatas.Length ; i++)
        {
            Vector3 pos;
            pos.x = dataTraps.trapDatas[i].position[0];
            pos.y = dataTraps.trapDatas[i].position[1];
            pos.z = dataTraps.trapDatas[i].position[2];

            LoadBuild(dataTraps.trapDatas[i].trapName, pos);
        }
    }
}
