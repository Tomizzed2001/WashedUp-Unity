using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [Header("Level Values")]
    [SerializeField]
    public int level = 1;

    [Header("Enemy Values")]
    [SerializeField]
    public int currentEnemyNum;
    public int toSpawn;

    [Header("Spawners")]
    private Spawner[] spawners;
    [SerializeField] Spawner[] day1Spawners;
    [SerializeField] Spawner[] day2Spawners;
    [SerializeField] Spawner[] day3Spawners;
    [SerializeField] Spawner[] day4Spawners;
    [SerializeField] Spawner[] day5Spawners;
    [SerializeField] Spawner[] day6Spawners;

    [Header("Managers")]
    [SerializeField] UIManager uiManager;
    [SerializeField] TimeManager timeManager;
    [SerializeField] SaveManager saveManager;

    [Header("Extras")]
    [SerializeField] private GameObject blockingGrid;
    [SerializeField] private GameObject notification;
    [SerializeField] private Boat boat;
    [SerializeField] private Objective boatObjective;
    [SerializeField] private GameObject recipeNotification;
    [SerializeField] private GameObject enemyCounter;
    [SerializeField] private Text enemyCounterText;

    private void Start()
    {
        level = timeManager.currentDay;
    }

    private void UpdateCounter()
    {
        enemyCounterText.text = toSpawn.ToString();
    }

    public void BeginSpawn()
    {
        enemyCounter.SetActive(true);
        toSpawn = 0;
        if (timeManager.currentDay == 1)
        {
            spawners = day1Spawners;
            for (int i = 0; i < day1Spawners.Length; i++)
            {
                Spawner spawner = day1Spawners[i];
                toSpawn += spawner.toSpawnCount;
                spawner.StartSpawn();
            }
        }
        else if (timeManager.currentDay == 2)
        {
            spawners = day2Spawners;
            for (int i = 0; i < day2Spawners.Length; i++)
            {
                Spawner spawner = day2Spawners[i];
                toSpawn += spawner.toSpawnCount;
                spawner.StartSpawn();
            }
        }
        else if (timeManager.currentDay == 3)
        {
            spawners = day3Spawners;
            for (int i = 0; i < day3Spawners.Length; i++)
            {
                Spawner spawner = day3Spawners[i];
                toSpawn += spawner.toSpawnCount;
                spawner.StartSpawn();
            }
        }
        else if (timeManager.currentDay == 4)
        {
            spawners = day4Spawners;
            for (int i = 0; i < day4Spawners.Length; i++)
            {
                Spawner spawner = day4Spawners[i];
                toSpawn += spawner.toSpawnCount;
                spawner.StartSpawn();
            }
        }
        else if (timeManager.currentDay == 5)
        {
            spawners = day5Spawners;
            for (int i = 0; i < day5Spawners.Length; i++)
            {
                Spawner spawner = day5Spawners[i];
                toSpawn += spawner.toSpawnCount;
                spawner.StartSpawn();
            }
        }
        else if (timeManager.currentDay == 6)
        {
            spawners = day6Spawners;
            for (int i = 0; i < day6Spawners.Length; i++)
            {
                Spawner spawner = day6Spawners[i];
                toSpawn += spawner.toSpawnCount;
                spawner.StartSpawn();
            }
        }
        UpdateCounter();
        StartCoroutine(CheckRaidEnd());
    }

    public void isLastEnemy()
    {
        toSpawn--;
        UpdateCounter();
        /*
        if (currentEnemyNum == 0)
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                if (!spawners[i].finishedSpawning)
                {
                    return;
                }
            }
            StartCoroutine(NightEnd());            
        }
        */
    }

    private IEnumerator CheckRaidEnd()
    {
        Debug.Log("Checking " + toSpawn);
        yield return new WaitForSeconds(2);
        if (toSpawn == 0)
        {
            StartCoroutine(NightEnd());
        }
        else
        {
            StartCoroutine(CheckRaidEnd());
        }
    }

    private IEnumerator NightEnd()
    {
        enemyCounter.SetActive(false);
        GameManager.Instance.audioManager.FadeRaid();
        uiManager.FadeScript.BlackOut();
        yield return new WaitForSeconds(2.5f);
        GameManager.Instance.UsePlayerCam();
        GameManager.Instance.audioManager.StopRaid(); 
        timeManager.goDay();
        StartCoroutine(SaveTime());
        if (timeManager.currentDay == 7)
        {
            GameManager.Instance.GameWin(true);
        }
        if (timeManager.currentDay == 3)
        {
            GameManager.Instance.EnableRecipesPart2();
            recipeNotification.SetActive(true);
        }
        if (timeManager.currentDay == 4)
        {
            blockingGrid.SetActive(false);
            notification.SetActive(true);
        }
        if (!boat.boatFixed)
        {
            boatObjective.objectiveDone = false;
        }


    }

    private IEnumerator SaveTime()
    {
        yield return new WaitForSeconds(2.5f);
        saveManager.Save();
    }
}
