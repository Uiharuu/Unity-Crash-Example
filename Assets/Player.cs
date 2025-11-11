using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;


    private float xInput;
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private int jumpForce = 8;
    private bool facingRight = true;

    [SerializeField] private float groundCheckDis = 1.4f;
    [SerializeField] private LayerMask ground;
    private bool isGrounded = true;

    private bool isMoving = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        CollisionCheck();
        InputHandle();
        AnimationHandle();
        FlipHandle();


    }

    private void InputHandle()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }
    private void AnimationHandle()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetFloat("xVelocity", rb.velocity.x);
    }

    private void FlipHandle()
    {
        if (rb.velocity.x > 0 && facingRight == false)
            Flip();
        else if (rb.velocity.x < 0 && facingRight == true)
            Flip();
    }
    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDis, ground);
    }

    private void Move()
    {
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        
        if (rb.velocity.x != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDis));
    }
}
