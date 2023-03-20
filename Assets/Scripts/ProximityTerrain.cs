using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTerrain : MonoBehaviour
{
    public GameObject obj;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            obj.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            obj.SetActive(true);
        }
    }
}
