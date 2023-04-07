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
    /// <summary>
    /// Controls player movement, Trampoline physics and Player Sprite Control
    /// This tutorial helped early on in the development stage:
    /// https://www.youtube.com/watch?v=dwcT-Dch0bA
    /// </summary>
    private float Move;
    public float speed;
    public float jump;
    public float maxMagnitude;
    private bool isFacingRight = true;
    public Animator animate;

    public bool canMove;

    private bool trampolineJump = false;
    private Collider2D platformCollider;


    private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource jumpSound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }   

    /// <summary>
    /// Update is called once per frame, checks if the player can move first for invincibility frames. Also there is an update for jumping,
    /// checks if player is on the ground and is not in a trampoline jump.
    /// </summary>
    void Update()
    {
        if(canMove == true)
        {
            Move = Input.GetAxis("Horizontal");
            animate.SetFloat("Speed", Mathf.Abs(Move));

        }
        FlipSprite();

        if (trampolineJump)
        {
            rb.velocity = Vector2.ClampMagnitude(new Vector2(Move * speed, rb.velocity.y), 50);
        } else
        {          
            rb.velocity = Vector2.ClampMagnitude(new Vector2(Move * speed, rb.velocity.y), maxMagnitude);

        }
        
        if (Input.GetAxisRaw("Vertical") < 0 && platformCollider != null && canMove == true)
        {
            platformCollider.enabled = false;
        } 
        

        if (Input.GetButtonDown("Jump") && isGrounded() && !trampolineJump && canMove == true)
        {
            jumpSound.Play();
            animate.SetBool("Jumping", true);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
           
        } else if  (isGrounded() || rb.velocity.y < 0.1f) {
            trampolineJump = false;
            animate.SetBool("Jumping", false);
        }

    }

    /// <summary>
    /// This mainly checks with collision with the trampoline game object 
    /// </summary>
    /// <param name="collision"></param>
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

        if (collision.gameObject.name.Contains("Trampoline"))
        {
            trampolineJump = true;
            animate.SetBool("Jumping", true);
        }

    }

    async void enablePlatform(Collider2D platform)
    {
        await Task.Delay(300);
        platform.enabled = true;

    }

    /// <summary>
    /// Returns true if the player is currently grounded and false if the player is not.
    /// </summary>
    /// <returns></returns>
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(new Vector3(groundCheck.position.x, groundCheck.position.y - 0.35f, groundCheck.position.z), 0.08f, groundLayer);
 
    }

    /// <summary>
    /// For flipping the sprite, rotates the entire sprite when the correct inputs are used.
    /// </summary>
    private void FlipSprite()
    {
        if(isFacingRight && Move < 0f || !isFacingRight && Move > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
