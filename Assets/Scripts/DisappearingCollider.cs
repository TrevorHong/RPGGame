using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DisappearingCollider : MonoBehaviour
{

    [SerializeField] private AudioSource collectSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collectSound.Play();
            gameObject.SetActive(false);
        }
    }
}
