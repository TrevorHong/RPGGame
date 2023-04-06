using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Threading.Tasks;
using UnityEngine;


/// <summary>
/// Makes the Textures covering the cave entrance disappear when the player enters the trigger area
/// </summary>
public class CaveCoverCollider : MonoBehaviour
{
    public GameObject mainObj;

    /// <summary>
    /// Sets the cover to be opaque at the beginning
    /// </summary>
    void Start()
    {
        UnityEngine.Component[] trs = mainObj.GetComponentsInChildren<Transform>(true);
        SpriteRenderer[] spr = new SpriteRenderer[trs.Length];

        foreach(SpriteRenderer sprite in spr)
        {
            Color tmp = sprite.color;
            tmp.a = 255;
            sprite.color = tmp;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            FadeOut();
        }
    }

    /// <summary>
    /// Changes the transparency of the cave cover textures and fades them out over a period of time
    /// </summary>
    async void FadeOut()
    {
        UnityEngine.Component[] trs = mainObj.GetComponentsInChildren<Transform>(true);
        SpriteRenderer[] spr = new SpriteRenderer[trs.Length - 1];

        for (int i = 0; i < trs.Length; i++)
        {
            if (trs[i].gameObject.name != mainObj.name)
            {
                spr[i - 1] = trs[i].gameObject.GetComponent<SpriteRenderer>();
            }
        }
        
        float alphaVal = spr[0].color.a;
        Color tmp = spr[0].color;

        for (int i = 0; i < 100; i++)
        {
            alphaVal -= 0.01f;
            tmp.a = alphaVal;

            foreach(SpriteRenderer sprite in spr)
            {
                sprite.color = tmp;
            }
            await Task.Delay(15);
        }

    }
}
