using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapTrap : Trap
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy.moveSpeed <0.1)
            {
                return;
            }
            if (enemy.enemyName == "Bear" || enemy.enemyName == "Bat")
            {
                return;
            }
            if (enemy.enemyName == "AxeMan")
            {
                enemy.TakeDamage(10);
                Destroy(gameObject);
            }
            enemy.moveSpeed /= 1.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy.enemyName == "Bear")
            {
                return;
            }
            enemy.moveSpeed *= 1.5f;
        }
    }
}
