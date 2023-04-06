using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


/// <summary>
/// Adds 1 health to the player upon collision trigger and makes the pickup disappear
/// </summary>
public class HealthPickup : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (collision.gameObject.GetComponent<Health>().health < collision.gameObject.GetComponent<Health>().healthbar.Length)
            collision.gameObject.GetComponent<Health>().health += 1;
            gameObject.SetActive(false);
        }
    }
}
