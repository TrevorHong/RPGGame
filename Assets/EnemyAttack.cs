using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyProjectile prefab;
    public Transform shootpos;

    public float cooldown = 5f;
    public float attacktime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        if((time - attacktime) > cooldown)
        {
            fireball();
            attacktime = time;
        }
    }

    void fireball()
    {
        Instantiate(prefab, shootpos.position, transform.rotation);
    }
}
