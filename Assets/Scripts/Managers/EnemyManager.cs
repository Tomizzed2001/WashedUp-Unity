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

    [Header("Managers")]
    [SerializeField] UIManager uiManager;
    [SerializeField] TimeManager timeManager;
    [SerializeField] SaveManager saveManager;

    private void Start()
    {
        level = timeManager.currentDay;
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
        uiManager.FadeScript.BlackOut();
        yield return new WaitForSeconds(2.5f);
        GameManager.Instance.UsePlayerCam();
        timeManager.goDay();
        saveManager.Save();
        if (timeManager.currentDay == 3)
        {
            GameManager.Instance.GameWin();
        }
    }
}
