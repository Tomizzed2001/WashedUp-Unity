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

    private void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<Waypoints>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
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
                Destroy(gameObject);
            }
        }
    }
}
