using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using UnityEngine;

public class Movement : MonoBehaviour

{
    private float Move;
    public float speed;
    public float jump;
    private bool isFacingRight = true;
    public Animator animate;

    private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }   

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        FlipSprite();
        animate.SetFloat("Speed", Mathf.Abs(Move));
        rb.velocity = new Vector2(Move * speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            animate.SetBool("Jumping", true);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            if(isGrounded())
            {
                animate.SetBool("Jumping", false);
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FlipSprite()
    {
        if(isFacingRight && Move < 0f || !isFacingRight && Move > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
