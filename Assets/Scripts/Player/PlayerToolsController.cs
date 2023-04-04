using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolsController : MonoBehaviour
{
    PlayerController playerController;
    PlayerBuild playerBuild;
    Rigidbody2D rb;

    [SerializeField] float offsetDistrance = 1f;        //Look Into these two
    [SerializeField] float sizeOfInteractableArea;

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
                //inventoryManager.removeItem(inventoryManager.getSelectedItemName(), 1);
                //GameObject newTower = Instantiate(tower, placement.position, Quaternion.identity);

                Build();
            }
            else if (inventoryManager.isSelectedWeapon())
            {
                Shoot();
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
        GameObject newProjectile = Instantiate(Projectile, pivot.position, pivot.rotation);
    }
}
