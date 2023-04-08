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
    [SerializeField] private float slingshotFireRate = 0.5f;
    [SerializeField] private float bowFireRate = 0.7f;
    private float nextShot = 0.0f;

    [Header("Managers")]
    [SerializeField] UIManager uiManager;
    [SerializeField] TowerManager towerManager;
    [SerializeField] InventoryManager inventoryManager;

    [Header("Weapon Related Fields")]
    [SerializeField] GameObject ProjectileSlingshot;
    [SerializeField] GameObject ProjectileArrowMetal;
    [SerializeField] GameObject ProjectileArrowStone;
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
            else if (inventoryManager.isSelectedStructure() && (playerBuild.canBuild || inventoryManager.isSelectedTrap()))
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
        towerManager.defencesPlaced++;
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
        if (inventoryManager.getSelectedItemName() == "Slingshot")
        {
            bool testStone = inventoryManager.CheckItem("Stone", 1);
            if (testStone)
            {
                inventoryManager.removeItem("Stone", 1);
                GameManager.Instance.audioManager.Slingshot();
                nextShot = Time.time + slingshotFireRate;
                GameObject newProjectile = Instantiate(ProjectileSlingshot, pivot.position, pivot.rotation);
            }
            else
            {
                Debug.Log("No Ammo");
            }
        }
        else if (inventoryManager.getSelectedItemName() == "Bow")
        {
            bool testArrowStone = inventoryManager.CheckItem("ArrowStone", 1);
            bool testArrowMetal = inventoryManager.CheckItem("ArrowMetal", 1);
            if (testArrowMetal)
            {
                inventoryManager.removeItem("ArrowMetal", 1);
                //Add arrow sound here
                nextShot = Time.time + bowFireRate;
                GameObject newProjectile = Instantiate(ProjectileArrowMetal, pivot.position, pivot.rotation);
            }
            else if (testArrowStone)
            {
                inventoryManager.removeItem("ArrowStone", 1);
                //Add arrow sound here
                nextShot = Time.time + bowFireRate;
                GameObject newProjectile = Instantiate(ProjectileArrowStone, pivot.position, pivot.rotation);
            }
            else
            {
                Debug.Log("No Ammo");
            }
        }
    }
}
