using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimeData
{
    public double totalSeconds;
    public int dayCount;

    public TimeData(double seconds, int days)
    {
        totalSeconds = seconds;
        dayCount = days;
    }
}
