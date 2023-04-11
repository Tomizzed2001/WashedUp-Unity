using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PitfallTrap : Trap
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy.enemyName == "AxeMan")
            {
                enemy.TakeDamage(10);
                Destroy(gameObject);
                return;
            }
            if (enemy.enemyName == "Bat")
            {
                return;
            }
            if (enemy.enemyName == "ShieldMan" || enemy.enemyName == "Bear" || enemy.enemyName == "Bat")
            {
                enemy.TakeDamage(10);
                Destroy(gameObject);
                return;
            }
            enemy.TakeDamage(100);
            Destroy(gameObject);
        }
    }
}
