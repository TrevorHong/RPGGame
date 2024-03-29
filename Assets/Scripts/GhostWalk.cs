using System;
using UnityEngine;


/// <summary>
/// Controls the movement of the ghost sprites to a random area
/// </summary>
public class GhostWalk : MonoBehaviour
{

    public double xBound;
    public double yBound;
    public float speed;

    private double lowerX, lowerY;
    private float walkDirX = -1;
    private float walkDirY = -1;
    private double destX, destY;
    private bool isFacingRight = false;
    private Vector2 walkAmt;
    private System.Random rnd= new System.Random();

    /// <summary>
    /// Calculates an initial destination and the lower bound of coordinates it can move to
    /// </summary>
    void Start()
    {
        lowerX = transform.position.x - xBound;
        lowerY = transform.position.y - yBound;
        destX = lowerX + rnd.NextDouble() * 2 * xBound;
        destY = lowerY + rnd.NextDouble() * 2 * yBound;

    }

    /// <summary>
    /// Sets a new destination if the destination has been reached, otherwise move towards the destination
    /// </summary>
    void Update()
    {
        if (Math.Round(transform.position.x, 3) == Math.Round(destX, 3))
        {
            destX = lowerX + rnd.NextDouble() * 2 * xBound;
        }

        if (Math.Round(transform.position.y, 3) == Math.Round(destY, 3))
        {
            destY = lowerY + rnd.NextDouble() * 2 * yBound;
        }

        walkDirX = (transform.position.x < destX) ? 1 : -1;
        walkDirY = (transform.position.y < destY) ? 1 : -1;

        walkAmt.x = walkDirX * speed * Time.deltaTime;
        walkAmt.y = walkDirY * speed * Time.deltaTime;
        transform.Translate(walkAmt);
        FlipSprite();

    }

    /// <summary>
    /// Flips the sprites to the correct direction
    /// </summary>
    private void FlipSprite()
    {
        if (isFacingRight && walkDirX < 0f || !isFacingRight && walkDirX > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
