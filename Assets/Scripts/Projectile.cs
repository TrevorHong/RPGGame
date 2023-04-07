using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /// <summary>
    /// Controls player projectiles when "Fire2" (K) input is pressed.
    /// </summary>
    public float speed = 5f;
    public int damage = 1;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// An OnTriggerEnter2D so that the projectile knows whether or not an enemy has been hit or not, changes the variables
    /// if so and destroys the game object on contact with one.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHit enemy = collision.gameObject.GetComponent<EnemyHit>();

        if (enemy != null)
        {
            enemy.hit = true;
            enemy.hitpoints -= damage;
            Destroy(gameObject);
        }
    }
}
