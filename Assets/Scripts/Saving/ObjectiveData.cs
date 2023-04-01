using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectiveData
{
    public bool[] activeObjectives;

    public ObjectiveData(bool[] objectives)
    {
        activeObjectives = objectives;
    }
}
