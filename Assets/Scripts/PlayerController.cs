using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*[SerializeField] float speed = 5f;*/
    [SerializeField] Animator animator;

    private Rigidbody2D rb;

    void Start()
    {

    }

    void Update()
    {
        HandleMovement();
        HandleCrouch();
        HandleJump();
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
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

    void HandleJump()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
