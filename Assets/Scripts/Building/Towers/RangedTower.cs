using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedTower : Tower
{
    [Header("Prefabs")]
    [SerializeField] GameObject Projectile;

    [Header("Transforms")]
    [SerializeField] Transform tower;
    [SerializeField] Transform pivot;

    protected override void Shoot()
    {
        base.Shoot();

        GameObject newProjectile = Instantiate(Projectile, tower.position, pivot.rotation);
    }
}
