using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float health;
    public SpriteRenderer[] spriteRenderer;
    public Sprite[] healthbar;
    public Sprite filled;
    public Sprite empty;
    public Animator animate;

    public Movement movecheck;


    [SerializeField] private int duration;
    private SpriteRenderer sprite;
    [SerializeField] private int flash;
    public Rigidbody2D rb;

    private bool invuln = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && !invuln)
        {
            health -= 1;
            rb.AddForce(new Vector2(2500f * collision.gameObject.GetComponent<EnemyPatrol>().walkingDirection, 300f));
            animate.SetBool("Jumping", true);
            IFrames();
        }
        if (collision.gameObject.layer == 7 && !invuln)
        {
            health -= 1;
        }
    }

    async void IFrames()
    {
        invuln = true;
        movecheck.canMove = false;
        movecheck.speed = 0;
        Physics2D.IgnoreLayerCollision(7, 9, true);
        for (int i = 0; i < flash; i++)
        {
            sprite.color = Color.gray;
            await Task.Delay(duration);
            sprite.color = Color.white;
            await Task.Delay(duration);

            if (i == flash / 2)
            {
                Physics2D.IgnoreLayerCollision(7, 9, false);
                movecheck.speed = 4;
                movecheck.canMove = true;
            }
        }
        invuln = false;
    }
}
