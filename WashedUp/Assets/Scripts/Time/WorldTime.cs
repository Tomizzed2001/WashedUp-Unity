using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTime : MonoBehaviour
{
    [SerializeField] float dayLength;
    [SerializeField] public TimeSpan currentTime;

    [SerializeField] TimeDisplay timeDisplay;
    [SerializeField] DayLight daylight;

    private float timeLength => dayLength / 1440;

    private void Start()
    {
        StartCoroutine(AddMinute());
    }

    private IEnumerator AddMinute()
    {
        currentTime += TimeSpan.FromMinutes(1);
        timeDisplay.timer = currentTime;
        timeDisplay.UpdateTime();
        daylight.UpdateLights();
        yield return new WaitForSeconds(timeLength);
        StartCoroutine(AddMinute());
    }
}
