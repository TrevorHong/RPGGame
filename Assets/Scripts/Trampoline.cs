using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float jump;
    public Animator animate;

    [SerializeField] private AudioSource trampolineSound;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            trampolineSound.Play();
            animate.SetBool("Touched", true);
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerBody.velocity = Vector2.ClampMagnitude(new Vector2(playerBody.velocity.x, jump), jump);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animate.SetBool("Touched", false);
        }
    }
}
