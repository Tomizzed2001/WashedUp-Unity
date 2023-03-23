using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D moveFilter;

    List<RaycastHit2D> collisions = new List<RaycastHit2D>();
    Vector2 moveInput;
    Rigidbody2D rb;

    Animator animator;
    SpriteRenderer spriteRenderer;

    public Vector2 lastPos;


    private void Start()
    {
        //Initialises Variables
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //Collision Logic 
        if (moveInput != Vector2.zero)
        {
            int count = rb.Cast(moveInput, moveFilter, collisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
            }
        }
        

        //Logic for the animation of the player and set last position
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            lastPos = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            animator.SetBool("isMoving", true);

            if(moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void OnMove(InputValue moveValue)
    {
        moveInput = moveValue.Get<Vector2>();
    }

    public void OnBuild()
    {
        rb.MovePosition(new Vector2(0,0));
    }
}