using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Attack : MonoBehaviour
{
    /// <summary>
    /// Player attack.
    /// This tutorial helped early on in the development stage:
    /// https://www.youtube.com/watch?v=sPiVz1k-fEs&t=420s&ab_channel=Brackeys
    /// </summary>
    public Animator animate;
    public Animator slash;

    public Transform attackpos;
    public float range = 0.5f;
    public LayerMask enemies;
    private float cooldown = 1.0f;
    private float attacktime = 0f;
    public int damage = 1;

    public int maxmana = 45;
    public int currentmana = 0;

    public Projectile prefab;
    public Transform shootpos;

    [SerializeField] private AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ///Variable of time to check the current timeframe and subtract it from attacktime, and check if it's larger than the cooldown
        ///This is used for attack delay
        float timecheck = Time.time;
        if(Input.GetButtonDown("Fire1") && (timecheck - attacktime) > cooldown)
        {       
            attackSound.Play();
            animate.SetTrigger("Attacking");
            slash.SetTrigger("AttackingSlash");
            MeleeAttack();
            attacktime = timecheck;
        }

        if(Input.GetButtonDown("Fire2") && (timecheck - attacktime) > cooldown && currentmana >= 15)
        {
            Magic();
        }
    }
    void MeleeAttack()
    {
        ///This checks for enemies within the range of the attack, and subtracts hp from any enemy 
        Collider2D[] attackhit = Physics2D.OverlapCircleAll(attackpos.position, range, enemies);

        foreach (Collider2D enemy in attackhit)
        {
            currentmana += 5;
            enemy.GetComponent<EnemyHit>().hitpoints -= damage;
            enemy.GetComponent<EnemyHit>().hit = true;
        }
    }

    void Magic()
    {
        Instantiate(prefab, shootpos.position, transform.rotation);
        currentmana -= 15;
    }

    private void OnDrawGizmosSelected()
    {
        ///Only for visual purposes to view the hitbox of the attack in the scene in unity.
        if (attackpos == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpos.position, range);
    }
}
