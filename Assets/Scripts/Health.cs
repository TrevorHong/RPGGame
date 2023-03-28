using System;
using System.Collections;
using System.Collections.Generic;
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


    [SerializeField] private float duration;
    private SpriteRenderer sprite;
    [SerializeField] private int flash;
    public Rigidbody2D rb;
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
        if (collision.gameObject.layer == 8)
        {
            health -= 1;
            rb.AddForce(new Vector2(2500f, 300f));
            animate.SetBool("Jumping", true);
            StartCoroutine(IFrames());
            animate.SetBool("Jumping", false);
        }
    }

    private IEnumerator IFrames()
    {
        movecheck.canMove = false;
        movecheck.speed = 0;
        Physics2D.IgnoreLayerCollision(7, 9, true);
        for (int i = 0; i < flash; i++)
        {
            sprite.color = Color.gray;
            yield return new WaitForSeconds(1);
            sprite.color = Color.white;
            yield return new WaitForSeconds(1);
        }
        Physics2D.IgnoreLayerCollision(7, 9, false);
        movecheck.canMove = true;
    }
}
