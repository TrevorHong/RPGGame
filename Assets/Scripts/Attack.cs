using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Attack : MonoBehaviour
{
    /// <summary>
    /// Player attack.
    /// </summary>
    public Animator animate;
    public Animator slash;

    public Transform attackpos;
    public float range = 0.5f;
    public LayerMask enemies;
    private float cooldown = 1.0f;
    private float attacktime = 0f;
    public int damage = 1;

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
    }
    void MeleeAttack()
    {
        ///This checks for enemies within the range of the attack, and subtracts hp from any enemy 
        Collider2D[] attackhit = Physics2D.OverlapCircleAll(attackpos.position, range, enemies);

        foreach (Collider2D enemy in attackhit)
        {
            //Magic magic = enemy.GetComponent<Magic>();
            //magic.baramount += 20;
            enemy.GetComponent<EnemyHit>().hitpoints -= damage;
            enemy.GetComponent<EnemyHit>().hit = true;
        }
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
