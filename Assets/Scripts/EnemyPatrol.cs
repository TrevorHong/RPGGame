using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy patrol and chasing script.
/// source: https://www.youtube.com/watch?v=ZExSz7x69j8&t=229s
/// </summary>
public class EnemyPatrol : MonoBehaviour
{
    public float leftBound;
    public float rightBound;
    public float speed;
    public float walkingDirection;
    Vector2 walkAmt;
    private float wallLeft, wallRight;
    private bool isFacingRight = false;

    [SerializeField] Transform player;
    [SerializeField] float chaseRange;
    [SerializeField] public float moveSpeed;
    Vector2 chaseAmt;
    [SerializeField] Transform point;

    // Start is called before the first frame update
    void Start()
    {
        wallLeft = transform.position.x - leftBound;
        wallRight = transform.position.x + rightBound;
    }

    // Update is called once per frame
    void Update()
    {

        if (CanSeePlayer(chaseRange))
        {
            ChasePlayer();
        }
        else
        {
            StopChasing();
        }
    }

    // Chase player by increasing the movement speed
    private void ChasePlayer()
    {
        chaseAmt.x = walkingDirection * moveSpeed * Time.deltaTime;
        if (transform.position.x > player.position.x)
        {
            walkingDirection = -1.0f;
        }
        else if (transform.position.x < player.position.x)
        {
            walkingDirection = 1.0f;
        }
        transform.Translate(chaseAmt);
        FlipSprite();
    }

    // If player is not in chase range, enemy stops chasing and goes back to normal patrolling route
    private void StopChasing()
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

    // Using a Raycast line to check if the player is touching the line, and returns true if the player is touching the line
    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = -distance;

        if(isFacingRight)
        {
            castDist = distance;
        }

        Vector2 endPos = point.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(point.position, endPos, 1 << LayerMask.NameToLayer("Player"));

        Debug.DrawLine(point.position, endPos, Color.blue);

        if (hit.collider != null)
        {
            if(hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }

            else
            {
                val = false;
            }
            Debug.DrawLine(point.position, hit.point, Color.yellow);
        }
        return val;
    }

    // Flips the sprite depending on the mob walking direction
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
