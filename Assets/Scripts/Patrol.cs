using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Basic patrol script for a npc
/// </summary>
public class Patrol : MonoBehaviour
{


    public float leftBound;
    public float rightBound;
    public float speed;
    public float walkingDirection;
    Vector2 walkAmt;
    private float wallLeft, wallRight;
    private bool isFacingRight = true;

    /// <summary>
    /// Sets the left and right bounds
    /// </summary>
    void Start()
    {
        wallLeft = transform.position.x - leftBound;
        wallRight = transform.position.x + rightBound;
    }

    /// <summary>
    /// Checks to make sure the npc is within the bounds, otherwise switch their direction and flip the sprites
    /// </summary>
    void Update()
    {
        walkAmt.x = walkingDirection * speed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= wallRight)
        {
            walkingDirection = -1.0f;
        }
        else if (walkingDirection < 0.0f && transform.position.x <= wallLeft)
        {
            walkingDirection = 1.0f;
        }
        transform.Translate(walkAmt);
        FlipSprite();
    }

    /// <summary>
    /// Flip the sprites
    /// </summary>
    private void FlipSprite()
    {
        if (isFacingRight && walkingDirection < 0f || !isFacingRight && walkingDirection > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
