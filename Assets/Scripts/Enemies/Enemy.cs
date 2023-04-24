using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Variables")]
    public float moveSpeed;
    public float health;
    public bool attackPlayer;
    public string enemyName;

    private Waypoints Wpoints;
    private int waypointIndex;

    private GameObject player;
    private Vector3 playerPos;

    private EnemyManager enemyManager;

    private void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<Waypoints>();
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("EnemyManager"))
        {
            enemyManager = gameObj.GetComponent<EnemyManager>();
        }
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        StartCoroutine(GetPlayerPos());
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            enemyManager.currentEnemyNum--;
            Debug.Log("Take damage call");
            enemyManager.isLastEnemy();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.LoseHealth();
        }
    }

    private IEnumerator GetPlayerPos()
    {
        yield return new WaitForSeconds(2);
        playerPos = player.transform.position;
        StartCoroutine(GetPlayerPos());
    }

    private void Update()
    {
        
        if (attackPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
        }
        else
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
                    Debug.Log("Made it to the end call");
                    enemyManager.isLastEnemy();
                    Destroy(gameObject);
                }
            }
        }

    }
}
