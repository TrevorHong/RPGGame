using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] Transform player;

    public Rigidbody2D rb;

    public int projectilespeed;

    
    void Start()
    {
        rb.velocity = transform.right * projectilespeed;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
