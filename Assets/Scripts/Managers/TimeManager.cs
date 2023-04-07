 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Time Settings")]
    [SerializeField] float dayLength;
    [SerializeField] int startTime;
    [SerializeField] int morningTime;

    [Header("Current day info")]
    [SerializeField]
    public int currentDay = 1;
    public TimeSpan currentTime;
    public double totalSeconds;
    

    [Header("Time output displays")]
    [SerializeField] TimeDisplay timeDisplay;
    [SerializeField] DayLight daylight;

    [Header("Output places")]
    [SerializeField] private Boat boat;
    [SerializeField] private ObjectManager objectManager;

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

    public void goDay()
    {
        currentTime = TimeSpan.FromMinutes(morningTime);
        currentDay++;
        objectManager.objectAppear(currentDay);
        boat.fixedToday = false;
        if (currentDay == 2)
        {
            GameManager.Instance.objectivesManager.Objective8();
        }
        if (!boat.boatFixed)
        {
            GameManager.Instance.objectivesManager.Objective7();
        }
    }

    private IEnumerator AddMinute()
    {
        currentTime += TimeSpan.FromMinutes(1);
        timeDisplay.timer = currentTime;
        totalSeconds = currentTime.TotalSeconds;

        timeDisplay.UpdateTime();
        daylight.UpdateLights();
        yield return new WaitForSeconds(timeLength);
        StartCoroutine(AddMinute());
    }
}
