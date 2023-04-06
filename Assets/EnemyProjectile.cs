using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public Rigidbody2D rb;

    public float direction;

    public int projectilespeed;

    public float disappear = 5;
    
    void Start()
    {
        rb.velocity = direction * transform.right * projectilespeed;
    }
    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        if (time < disappear)
        {
            Debug.Log(time);
            Destroy(gameObject);
        }
    }
}
