using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float health;
    public SpriteRenderer[] spriteRenderer;
    public Sprite[] healthbar;
    public Sprite filled;
    public Sprite empty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            health -= 1;
            Debug.Log(health);
        }

        for (int i = 0; i < healthbar.Length; i++)
        {
            if (i < health)
            {
                spriteRenderer[i].sprite = filled;
            }
            else
            {
                spriteRenderer[i].sprite = empty;
            }
        }
    }
}
