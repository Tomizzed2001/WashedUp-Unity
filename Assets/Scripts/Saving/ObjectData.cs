using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectData
{
    public bool[] isBroken;

    public ObjectData(bool[] broken)
    {
        isBroken = broken;
    }
}
