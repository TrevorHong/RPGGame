using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform enemy;

    public float leftBound;
    public float rightBound;
    public float speed;
    public float walkingDirection;
    Vector2 walkAmt;
    private float wallLeft, wallRight;
    private bool isFacingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        wallLeft = transform.position.x - leftBound;
        wallRight = transform.position.x + rightBound;
    }

    // Update is called once per frame
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
