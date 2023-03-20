using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DisappearingCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
