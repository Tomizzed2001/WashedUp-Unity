using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolsController : MonoBehaviour
{
    PlayerController playerController;
    Rigidbody2D rb;

    [SerializeField] float offsetDistrance = 1f;        //Look Into these two
    [SerializeField] float sizeOfInteractableArea;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
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
}
