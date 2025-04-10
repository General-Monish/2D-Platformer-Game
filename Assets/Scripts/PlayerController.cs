using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float groundCheckDistance = 2f;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] Animator animator;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        HandleMovement(horizontalInput);
        PlayerMovementAnimationLeftAndRight(horizontalInput);
        HandleCrouch();
        Jump();
    }
    
    void HandleMovement( float horizontal)
    {
        Vector3 MovementDirection = transform.position;
        MovementDirection.x += horizontal * speed * Time.deltaTime;
        transform.position= MovementDirection;
    }
    private void PlayerMovementAnimationLeftAndRight(float horizontalInput)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Vector3 scale = transform.localScale;

        if (horizontalInput < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        else if (horizontalInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }
    }
    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && OnGround())
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
        }
        else if (OnGround())
        {
            animator.SetBool("Jump", false);
        }
    }
    private bool OnGround()
    {
        Vector2 pos = transform.position;
        Vector2 dir = Vector2.down;
        float distance = groundCheckDistance;
        RaycastHit2D raycastHit2DHit = Physics2D.Raycast(pos, dir, groundCheckDistance,groundLayer);
        if (raycastHit2DHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    } // checking Onground using Raycast

}
