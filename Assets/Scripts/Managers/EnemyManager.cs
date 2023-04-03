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
            level++;
            if (level == 3)
            {
                GameManager.Instance.GameWin();
            }
            else
            {
                StartCoroutine(NightEnd());
            }            
        }
    }

    private IEnumerator NightEnd()
    {
        Debug.Log("Fadeout");
        uiManager.FadeScript.BlackOut();
        yield return new WaitForSeconds(2.5f);
        GameManager.Instance.UsePlayerCam();
        timeManager.goDay();
    }
}
