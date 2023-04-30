using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent
{
    public float Health {  get; private set; }

    public HealthComponent(float health)
    {
        Health = health;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

}
