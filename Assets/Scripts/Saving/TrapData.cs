using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TrapData
{
    public float[] position;
    public string trapName;

    public TrapData(Trap trap)
    {
        trapName = trap.trapName;

        position = new float[3];

        position[0] = trap.transform.position.x;
        position[1] = trap.transform.position.y;
        position[2] = trap.transform.position.z;
    }
}
