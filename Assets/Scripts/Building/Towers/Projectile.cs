using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileDamage;

    private void Awake()
    {
        StartCoroutine(despawner());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy.health > 0)
            {
                enemy.TakeDamage(projectileDamage);
            }
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * projectileSpeed;
    }

    private IEnumerator despawner()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
