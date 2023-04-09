using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Level Values")]
    [SerializeField]
    public int level = 1;

    [Header("Enemy Values")]
    [SerializeField]
    public int currentEnemyNum;

    [Header("Spawners")]
    [SerializeField] Spawner[] day1Spawners;
    [SerializeField] Spawner[] day2Spawners;

    [Header("Managers")]
    [SerializeField] UIManager uiManager;
    [SerializeField] TimeManager timeManager;
    [SerializeField] SaveManager saveManager;

    private void Start()
    {
        level = timeManager.currentDay;
    }

    public void BeginSpawn()
    {
        if (timeManager.currentDay == 1)
        {
            for (int i = 0; i < day1Spawners.Length; i++)
            {
                Spawner spawner = day1Spawners[i];
                spawner.StartSpawn();
            }
        }
        else if (timeManager.currentDay == 2)
        {
            for (int i = 0; i < day2Spawners.Length; i++)
            {
                Spawner spawner = day2Spawners[i];
                spawner.StartSpawn();
            }
        }
    }

    public void isLastEnemy()
    {
        if (currentEnemyNum == 0)
        {
            for (int i = 0; i < day1Spawners.Length; i++)
            {
                if (!day1Spawners[i].finishedSpawning)
                {
                    return;
                }
            }
            StartCoroutine(NightEnd());            
        }
    }

    private IEnumerator NightEnd()
    {
        GameManager.Instance.audioManager.FadeRaid();
        uiManager.FadeScript.BlackOut();
        yield return new WaitForSeconds(2.5f);
        GameManager.Instance.UsePlayerCam();
        GameManager.Instance.audioManager.StopRaid(); 
        timeManager.goDay();
        StartCoroutine(SaveTime());
        if (timeManager.currentDay == 3)
        {
            GameManager.Instance.GameWin();
        }
    }

    private IEnumerator SaveTime()
    {
        yield return new WaitForSeconds(2.5f);
        saveManager.Save();
    }
}
