using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int hitpoints = 3;

    public bool hit = false;
    public Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true && hitpoints > 0)
        {
            hitanimate();
        }
    }
    async void hitanimate()
    {
        animate.SetBool("damage", true);
        await Task.Delay(1);
        animate.SetBool("damage", false);
        hit = false;
        await Task.Delay(1);

    }
}
