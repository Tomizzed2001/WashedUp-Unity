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
}
