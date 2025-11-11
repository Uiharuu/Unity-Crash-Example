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
        xInput = Input.GetAxisRaw("Horizontal");
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
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
        anim.SetBool("isMoving", isMoving);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
