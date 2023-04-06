using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Threading.Tasks;
using UnityEngine;

public class CaveCoverCollider : MonoBehaviour
{
    public GameObject mainObj;

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
