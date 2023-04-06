using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


/// <summary>
/// Makes the Textures covering the house disappear/reappear when the player enters/exits the trigger area
/// </summary>
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


    /// <summary>
    /// Makes the sprites fade out over a period of time
    /// </summary>
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

    /// <summary>
    /// Makes the sprites fade in over a period of time
    /// </summary>
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
