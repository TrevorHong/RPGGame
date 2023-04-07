using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    /// <summary>
    /// This controls the enemy projectile for the boss monster.
    /// </summary>
    public Rigidbody2D rb;

    public float direction;

    public int projectilespeed;

    public float disappear = 5;

    private float deltaTime;
    

    /// <summary>
    /// Changes the velocity based on the built in projectile speed, always technically goes right but direction changes that so it can also go left.
    /// </summary>
    void Start()
    {
        rb.velocity = direction * transform.right * projectilespeed;
    }
    // Update is called once per frame. This deletes the projectile if enough time has passed so they don't infinitely go through the level
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime > disappear)
        {
            Destroy(gameObject);
        }
    }
}
