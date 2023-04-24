using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemy spawn settings")]
    [SerializeField] public int toSpawnCount = 10;
    [SerializeField] private int initialDelay;
    [SerializeField] private float spawnDelay;

    [Header("Enemies to spawn")]
    [SerializeField] private GameObject enemyToSpawn;
    public bool finishedSpawning = false;
    public int enemyCurrentCount = 0;

    [Header("Enemy Manager")]
    private EnemyManager enemyManager;

    private void Start()
    {
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("EnemyManager"))
        {
            enemyManager = gameObj.GetComponent<EnemyManager>();
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(InitialSpawn(initialDelay, enemyToSpawn, spawnDelay));
    }

    private IEnumerator InitialSpawn(float initialWait, GameObject enemy, float interval)
    {
        yield return new WaitForSeconds(initialWait);
        Instantiate(enemy, transform.position, Quaternion.identity);
        enemyCurrentCount++;
        enemyManager.currentEnemyNum++;
        StartCoroutine(SpawnEnemy(interval, enemy));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if (enemyCurrentCount < toSpawnCount)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            enemyCurrentCount++;
            enemyManager.currentEnemyNum++;
            StartCoroutine(SpawnEnemy(interval, enemy));
        }
        else
        {
            finishedSpawning = true;
            //enemyManager.isLastEnemy();
        }
    }
}
