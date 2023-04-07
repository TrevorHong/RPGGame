using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls behaviour of water
/// </summary>
public class Water : MonoBehaviour
{
    [SerializeField] private AudioSource waterSound;

    /// <summary>
    /// Adjusts the gravity and drag of the player to reflect moving in a denser medium
    /// </summary>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            waterSound.Play();
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerBody.gravityScale = 2;
            playerBody.drag = 5;
        }
    }


    /// <summary>
    /// Adjusts the gravity and drag of the player to reflect moving in air
    /// </summary>
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerBody.gravityScale = 3;
            playerBody.drag = 1;
        }
    }
}
