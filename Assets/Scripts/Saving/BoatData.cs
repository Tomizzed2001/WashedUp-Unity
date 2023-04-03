using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoatData
{
    public int boatTier;
    public bool fixedToday;
    public bool boatFixed;

    public BoatData(int boatLevel, bool todayFix, bool isFixed)
    {
        boatTier = boatLevel;
        fixedToday = todayFix;
        boatFixed = isFixed;
    }
}
