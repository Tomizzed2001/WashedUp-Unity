using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TowerData
{
    public float[] position;
    public string towerName;

    public TowerData(Tower tower)
    {
        towerName = tower.towerName;

        position = new float[3];

        position[0] = tower.transform.position.x;
        position[1] = tower.transform.position.y;
        position[2] = tower.transform.position.z;
    }
}
