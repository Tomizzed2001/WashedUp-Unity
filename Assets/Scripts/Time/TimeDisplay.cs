using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public Text WorldTime;
    public TimeSpan timer;

    public void UpdateTime()
    {
        WorldTime.text = timer.ToString(format:@"hh\:mm");
    }
}
