using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AllTrapData
{
    public TrapData[] trapDatas;

    public AllTrapData(TrapData[] trapDatas)
    {
        this.trapDatas = trapDatas;
    }
}
