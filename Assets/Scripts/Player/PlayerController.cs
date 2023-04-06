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

    private bool freezeMovement = false;

    [SerializeField] private GameObject FadeScreen;
    [SerializeField] private AudioManager audioManager;

    private void Start()
    {
        //Initialises Variables
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (freezeMovement)
        {
            return;
        }

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
            audioManager.FootStep(true);
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
            audioManager.FootStep(false);
            animator.SetBool("isMoving", false);
        }
    }

    void OnMove(InputValue moveValue)
    {
        moveInput = moveValue.Get<Vector2>();
    }

    public void OnBuild()
    {
        rb.MovePosition(new Vector2(2.167939f, 1.40794f));
    }

    public void FreezeMovement()
    {
        freezeMovement = true;
    }

    public void UnFreezeMovement(float seconds)
    {
        StartCoroutine(EnableMovement(seconds));
    }

    private IEnumerator EnableMovement(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        FadeScreen.SetActive(false);
        freezeMovement = false;
    }

    public void SavePlayer()
    {
        Save.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = Save.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }
}