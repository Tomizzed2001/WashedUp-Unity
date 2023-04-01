using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Time Settings")]
    [SerializeField] float dayLength;
    [SerializeField] int startTime;

    [Header("Current day info")]
    public TimeSpan currentTime;
    public double totalSeconds;
    public int currentDay = 1;

    [Header("Time output displays")]
    [SerializeField] TimeDisplay timeDisplay;
    [SerializeField] DayLight daylight;

    private float timeLength => dayLength / 1440;

    private void Start()
    {
        currentTime = TimeSpan.FromMinutes(startTime);
        StartCoroutine(AddMinute());
    }

    public void SaveTime()
    {
        Save.SaveTime(totalSeconds, currentDay);
    }

    public void LoadTime()
    {
        TimeData data = Save.LoadTime();

        currentTime = TimeSpan.FromSeconds(data.totalSeconds);
        currentDay = data.dayCount;
    }

    public void goNight(int nightTime)
    {
        currentTime = TimeSpan.FromMinutes(nightTime);

    }

    private IEnumerator AddMinute()
    {
        currentTime += TimeSpan.FromMinutes(1);
        timeDisplay.timer = currentTime;
        totalSeconds = currentTime.TotalSeconds;
        if (totalSeconds % 86400 == 0)
        {
            currentDay++;
            Debug.Log(currentDay);
        }

        timeDisplay.UpdateTime();
        daylight.UpdateLights();
        yield return new WaitForSeconds(timeLength);
        StartCoroutine(AddMinute());
    }
}
