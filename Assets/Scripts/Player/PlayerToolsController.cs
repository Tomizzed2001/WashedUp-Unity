using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolsController : MonoBehaviour
{
    PlayerController playerController;
    PlayerBuild playerBuild;
    Rigidbody2D rb;

    [Header("Tools Values")]
    [SerializeField] private float offsetDistrance = 1f;
    [SerializeField] private float sizeOfInteractableArea;
    [SerializeField] private float fireRate = 0.5f;
    private float nextShot = 0.0f;

    [Header("Managers")]
    [SerializeField] UIManager uiManager;
    [SerializeField] TowerManager towerManager;
    [SerializeField] InventoryManager inventoryManager;

    [Header("Weapon Related Fields")]
    [SerializeField] GameObject Projectile;
    [SerializeField] Transform player;
    [SerializeField] Transform pivot;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerBuild = GetComponent<PlayerBuild>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !uiManager.InventoryOpen)
        {
            if (inventoryManager.isSelectedTool())
            {
                UseTool();
            }
            else if (inventoryManager.isSelectedStructure() && playerBuild.canBuild)
            {
                Build();
            }
            else if (inventoryManager.isSelectedWeapon())
            {
                if (Time.time > nextShot)
                {
                    Shoot();
                }
            }
            else
            {
                UseTool();
            }
        }
    }

    private void Build()
    {
        towerManager.Build(inventoryManager.getSelectedItemName());
    }

    private void UseTool()
    {
        Vector2 pos = rb.position + playerController.lastPos * offsetDistrance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            UseTool hit = c.GetComponent<UseTool>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }

    private void Shoot()
    {
        nextShot = Time.time + fireRate;
        GameObject newProjectile = Instantiate(Projectile, pivot.position, pivot.rotation);
    }
}
