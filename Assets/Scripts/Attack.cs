using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Calling animator here to 
    public Animator animate;

    public Transform attackpos;
    public float range = 0.5f;
    public LayerMask enemies;
    [SerializeField] private AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            attackSound.Play();
            animate.SetTrigger("Attacking");
            MeleeAttack();
        }
    }
    void MeleeAttack()
    {
        Collider2D[] attackhit = Physics2D.OverlapCircleAll(attackpos.position, range, enemies);

        foreach (Collider2D enemy in attackhit)
        {
            Debug.Log("works");
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackpos == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpos.position, range);
    }
}
