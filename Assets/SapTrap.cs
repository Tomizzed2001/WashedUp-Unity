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
            if (enemy.enemyName == "Bear")
            {
                return;
            }
            if (enemy.enemyName == "AxeMan")
            {
                enemy.TakeDamage(10);
                Destroy(gameObject);
            }
            enemy.moveSpeed /= 2;
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
            enemy.moveSpeed *= 2;
        }
    }
}
