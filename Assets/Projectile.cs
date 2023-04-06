using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
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
