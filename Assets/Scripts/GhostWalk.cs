using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        lowerX = transform.position.x - xBound;
        lowerY = transform.position.y - yBound;
        destX = lowerX + rnd.NextDouble() * 2 * xBound;
        destY = lowerY + rnd.NextDouble() * 2 * yBound;

    }

    // Update is called once per frame
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
