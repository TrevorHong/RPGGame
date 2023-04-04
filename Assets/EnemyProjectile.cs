using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] Transform player;

    public float detectrange;
    public GameObject projectile;
    public Transform offset;

    public int cooldown;
    public int projectilespeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.right * Time.deltaTime * projectilespeed;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectrange)
        {
            Instantiate(projectile, offset.position, transform.rotation);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
