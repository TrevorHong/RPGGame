using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ProximityTerrain : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private float alphaVal;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            FadeOut();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            FadeIn();
        }
    }

    async void FadeOut()
    {
        alphaVal = spriteRenderer.color.a;
        Color tmp = spriteRenderer.color;

        for (int i = 0; i < 100; i++)
        {
            alphaVal -= 0.01f;
            tmp.a = alphaVal;
            spriteRenderer.color = tmp;
            await Task.Delay(10);
        }

    }

    async void FadeIn()
    {
        alphaVal = spriteRenderer.color.a;
        Color tmp = spriteRenderer.color;

        for (int i = 0; i < 100; i++)
        {
            alphaVal += 0.01f;
            tmp.a = alphaVal;
            spriteRenderer.color = tmp;
            await Task.Delay(10);
        }
    }
}
