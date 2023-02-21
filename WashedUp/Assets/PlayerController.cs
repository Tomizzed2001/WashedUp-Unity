using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float collisionOffset =0.05f;
    public ContactFilter2D moveFilter;

    List<RaycastHit2D> collisions = new List<RaycastHit2D>(); 
    Vector2 moveInput;
    Rigidbody2D collisionBox;

    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        collisionBox = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
        {
            bool movePossible = canMove(moveInput);

            if (movePossible)
            {
                movePossible = canMove(new Vector2(moveInput.x, 0));

                if (!movePossible)
                {
                    movePossible = canMove(new Vector2(0, moveInput.y));
                }
            }

            animator.SetBool("isMoving", movePossible);
        }
        else 
        {
            animator.SetBool("isMoving", false);
        }

        if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private bool canMove(Vector2 direction)
    {
        int count = collisionBox.Cast(moveInput, moveFilter, collisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            collisionBox.MovePosition(collisionBox.position + moveInput * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue moveValue)
    {
        moveInput = moveValue.Get<Vector2>();
    }
}
