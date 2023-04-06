using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// Teleports the player to another location upon touching the collider
/// </summary>
public class Teleport : MonoBehaviour
{
    public Transform trs;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            trs.position = new Vector2(92.58f, 8.26f); 
        }
    }
}
