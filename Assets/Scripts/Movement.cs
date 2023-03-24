using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading.Tasks;
using UnityEngine;

public class Movement : MonoBehaviour

{
    private float Move;
    public float speed;
    public float jump;
    public float maxMagnitude;
    private bool isFacingRight = true;
    public Animator animate;

    private bool trampolineJump = false;
    private Collider2D platformCollider;


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
        if (trampolineJump)
        {
            rb.velocity = Vector2.ClampMagnitude(new Vector2(Move * speed, rb.velocity.y), 50);
        } else
        {
            rb.velocity = Vector2.ClampMagnitude(new Vector2(Move * speed, rb.velocity.y), maxMagnitude);
        }
        
        if (Input.GetAxisRaw("Vertical") < 0 && platformCollider != null)
        {
            platformCollider.enabled = false;
        } 
        
        //if (isGrounded() && Input.GetAxisRaw("Vertical") == 0)
        //{
        //    platformTime = 0;
        //} else if (!isGrounded() && Input.GetAxisRaw("Vertical") == 0)
        //{
        //    platformTime += Time.deltaTime;
        //}

        if (Input.GetButtonDown("Jump") && isGrounded() && !trampolineJump)
        {
            animate.SetBool("Jumping", true);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
           
        } else if  (isGrounded() && rb.velocity.y < 0.1f) {
            trampolineJump = false;
            animate.SetBool("Jumping", false);
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Trampoline"))
        {
            trampolineJump = true;
            animate.SetBool("Jumping", true);
        } else if (collision.gameObject.name.Contains("Platform"))
        {
            platformCollider = collision.gameObject.GetComponent<Collider2D>();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (platformCollider!= null)
        {
            enablePlatform(platformCollider);
            platformCollider = null;
        }

    }

    async void enablePlatform(Collider2D platform)
    {
        await Task.Delay(300);
        platform.enabled = true;

    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(new Vector3(groundCheck.position.x, groundCheck.position.y - 0.35f, groundCheck.position.z), 0.08f, groundLayer);
 
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
