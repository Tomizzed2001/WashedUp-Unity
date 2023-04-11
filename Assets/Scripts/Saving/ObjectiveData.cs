using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectiveData
{
    public bool[] activeObjectives;
    public bool[] doneObjectives;

    public ObjectiveData(bool[] objectives, bool[] finishedObjectives)
    {
        activeObjectives = objectives;
        doneObjectives = finishedObjectives;
    }
}
