using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public Rigidbody2D rb;

    public float direction;

    public int projectilespeed;

    public float disappear = 5;

    private float deltaTime;
    
    void Start()
    {
        rb.velocity = direction * transform.right * projectilespeed;
    }
    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime > disappear)
        {
            Destroy(gameObject);
        }
    }
}
