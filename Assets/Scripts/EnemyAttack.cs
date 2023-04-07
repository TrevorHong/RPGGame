using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    /// <summary>
    /// Controls Enemy projectile attacks
    /// </summary>
    public EnemyProjectile prefab;
    public Transform shootpos;

    public float cooldown = 5f;
    public float attacktime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called once per frame. This checks thee current time to make sure that the enemy doesn't spam the projectile
    /// </summary>
    void Update()
    {
        float time = Time.time;
        if((time - attacktime) > cooldown)
        {
            fireball();
            attacktime = time;
        }
    }

    /// <summary>
    /// Creates the fireball, also flips the direction of the fireball based on the walking direction in enemy patrol
    /// </summary>
    void fireball()
    {
        Transform fab = Instantiate(prefab, shootpos.position, transform.rotation).GetComponent<Transform>();
        fab.GetComponent<EnemyProjectile>().direction = gameObject.GetComponent<EnemyPatrol>().walkingDirection;
    }
}
