using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HouseData
{
    public bool houseBuilt;

    public HouseData(bool buildingStatus)
    {
        houseBuilt = buildingStatus;
    }
}
