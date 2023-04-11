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
    [SerializeField] private GameObject raidInfo;
    [SerializeField] public GameObject blockingGrid;
    [SerializeField] private GameObject sleepButton;

    [Header("Force Spawning Systems")]
    [SerializeField] private UIManager uiManager;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private PlayerController playerController;

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
        if (currentDay >= 4)
        {
            blockingGrid.SetActive(true);
        }
    }

    public void goNight(int nightTime)
    {
        currentTime = TimeSpan.FromMinutes(nightTime);

    }

    public void goDay()
    {
        currentTime = TimeSpan.FromMinutes(morningTime);
        currentDay++;
        objectManager.ObjectRespawn(currentDay);
        boat.fixedToday = false;
        if (currentDay == 2)
        {
            GameManager.Instance.objectivesManager.ShowExplore();
        }
        if (!boat.boatFixed)
        {
            GameManager.Instance.objectivesManager.ShowFix();
        }
    }

    private IEnumerator AddMinute()
    {
        currentTime += TimeSpan.FromMinutes(1);
        timeDisplay.timer = currentTime;
        totalSeconds = currentTime.TotalSeconds;

        if (currentTime.TotalMinutes == 1320) //1320
        {
            StartCoroutine(TriggerSpawn());
        }

        timeDisplay.UpdateTime();
        daylight.UpdateLights();
        yield return new WaitForSeconds(timeLength);
        StartCoroutine(AddMinute());
    }

    public IEnumerator TriggerSpawn()
    {
        uiManager.FadeScript.BlackOut();
        yield return new WaitForSeconds(2.5f);
        playerController.OnBuild();
        GameManager.Instance.UseRaidCam();
        goNight(1400);
        GameManager.Instance.audioManager.PlayRaid();
        yield return new WaitForSeconds(2.5f);
        enemyManager.BeginSpawn();
        if (currentDay == 1)
        {
            Time.timeScale = 0f;
            raidInfo.SetActive(true);
        }
        sleepButton.SetActive(false);
    }
}
