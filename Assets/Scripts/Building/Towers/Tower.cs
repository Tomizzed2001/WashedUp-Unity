using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower Settings")]
    [SerializeField] private float damage;
    [SerializeField] private float shootDelay;

    [Header("Current Enemies")]
    [SerializeField] private List<GameObject> enemies;
    public GameObject currentTarget;

    private void Start()
    {
        StartCoroutine(ShootEnemy(shootDelay));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Add(collision.gameObject);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Remove(collision.gameObject);
        }
    }

    private void UpdateCurrentTarget()
    {
        if (enemies != null && enemies.Any())
        {
            currentTarget = enemies[0];
        }
        else
        {
            currentTarget = null;
        }
    }

    protected virtual void Shoot()
    {
        if (currentTarget == null)
        {
            return;
        }
    }

    private void Update()
    {
        UpdateCurrentTarget();
    }

    private IEnumerator ShootEnemy(float shootDelay)
    {
        if (currentTarget != null)
        {
            Shoot();
        }
        yield return new WaitForSeconds(shootDelay);
        StartCoroutine(ShootEnemy(shootDelay));
    }

}
