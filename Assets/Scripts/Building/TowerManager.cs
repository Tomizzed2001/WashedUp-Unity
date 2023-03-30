using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] GameObject[] Towers;
    [SerializeField] Transform PlacementZone;
    [SerializeField] InventoryManager inventoryManager;

    public void Build(string towerName)
    {
        for (int i = 0; i < Towers.Length; i++)
        {
            if (towerName == Towers[i].name)
            {
                inventoryManager.removeItem(towerName, 1);
                GameObject newTower = Instantiate(Towers[i], PlacementZone.position, Quaternion.identity);
            }
        }
    }

    public void LoadBuild(string towerName, Vector3 pos)
    {
        for (int i = 0; i < Towers.Length; i++)
        {
            if (towerName == Towers[i].name)
            {
                Debug.Log("Match");
                GameObject newTower = Instantiate(Towers[i], pos, Quaternion.identity);
            }
        }
    }

    public void SaveTowers()
    {
        Save.SaveTower(GameObject.FindObjectsOfType<Tower>());
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
    }
}
