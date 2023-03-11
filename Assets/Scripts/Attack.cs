using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            animate.SetTrigger("Attacking");
        }
    }
}
