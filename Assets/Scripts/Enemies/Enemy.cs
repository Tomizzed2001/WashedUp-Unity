using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Variables")]
    public float moveSpeed;
    public float health;

    private Waypoints Wpoints;
    private int waypointIndex;

    private EnemyManager enemyManager;

    private void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<Waypoints>();
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("EnemyManager"))
        {
            enemyManager = gameObj.GetComponent<EnemyManager>();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            enemyManager.currentEnemyNum--;
            enemyManager.isLastEnemy();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            if (waypointIndex < Wpoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                GameManager.Instance.LoseHealth();
                enemyManager.currentEnemyNum--;
                enemyManager.isLastEnemy();
                Destroy(gameObject);
            }
        }
    }
}
