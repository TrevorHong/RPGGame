using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Background music trigger.
/// </summary>
public class MusicTrigger : MonoBehaviour
{

    [SerializeField] private AudioSource bgSound;

    // If player is in the gameobject, plays the music
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            bgSound.Play();
        }
    }

    // If player leaves the gameobject, stops the music
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            bgSound.Stop();
        }
    }
}
