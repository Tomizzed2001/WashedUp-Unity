using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemy spawn settings")]
    [SerializeField] private int toSpawnCount = 10;
    [SerializeField] private int initialDelay;
    [SerializeField] private float spawnDelay;

    [Header("Enemies to spawn")]
    [SerializeField] private GameObject enemyToSpawn;

    private int enemyCurrentCount = 0;

    private void Start()
    {
        //StartCoroutine(SpawnEnemy(spawnDelay, enemyToSpawn));
    }

    public void StartSpawn()
    {
        StartCoroutine(InitialSpawn(initialDelay, enemyToSpawn, spawnDelay));
    }

    private IEnumerator InitialSpawn(float initialWait, GameObject enemy, float interval)
    {
        yield return new WaitForSeconds(initialWait);
        GameObject newEnemy = Instantiate(enemy);
        enemyCurrentCount++;
        StartCoroutine(SpawnEnemy(interval, enemy));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if (enemyCurrentCount < toSpawnCount)
        {
            GameObject newEnemy = Instantiate(enemy);
            enemyCurrentCount++;
            StartCoroutine(SpawnEnemy(interval, enemy));
        }
    }
}
