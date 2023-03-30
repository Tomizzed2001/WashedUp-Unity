using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AllTowerData
{
    public TowerData[] towerDatas;

    public AllTowerData(TowerData[] towerDatas)
    {
        this.towerDatas = towerDatas;
    }
}
