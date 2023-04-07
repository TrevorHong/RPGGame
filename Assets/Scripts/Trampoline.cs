using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to control trampoline bounce behaviour
/// </summary>
public class Trampoline : MonoBehaviour
{
    public float jump;
    public Animator animate;

    [SerializeField] private AudioSource trampolineSound;


    /// <summary>
    /// Adds a set force to the player when they touch the trampoline
    /// </summary>
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

    /// <summary>
    /// Adds a set force to the player when they stop touching the trampoline
    /// </summary>
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animate.SetBool("Touched", false);
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerBody.velocity = Vector2.ClampMagnitude(new Vector2(playerBody.velocity.x, jump), jump);
        }
    }
}
