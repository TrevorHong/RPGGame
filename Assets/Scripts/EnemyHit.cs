using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHit : MonoBehaviour
{
    /// <summary>
    /// Controls enemy hit control and enemy health
    /// </summary>
    public int hitpoints = 3;

    SpriteRenderer spriteRenderer;
    public bool hit = false;
    public GameObject enemy;
    public Animator animate;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    /// <summary>
    /// Update is called once per frame. This checks for certain HP thresholds on certain enemies, both boss and regular enemy
    /// </summary>
    void Update()
    {
        if (hit == true && hitpoints > 0)
        {
            hitanimate();
        }
        if (hitpoints == 0 && enemy.gameObject.CompareTag("Boss"))
        {
            bossdeath();
        }

        if (hitpoints == 0)
        {
            death();
        }
    }

    /// <summary>
    /// A special condition for bosses to switch the scene.
    /// </summary>
    async void bossdeath()
    {
        death();
        await Task.Delay(1000);
        SceneManager.LoadScene("WinScreen");
    }
    /// <summary>
    /// Used for animating all enemies by setting parameters in the animator tree
    /// </summary>
    async void hitanimate()
    {
        animate.SetBool("damage", true);
        await Task.Delay(1);
        animate.SetBool("damage", false);
        hit = false;
        await Task.Delay(1);

    }
    /// <summary>
    /// This is what happens when a regular enemy dies, 
    /// </summary>
    async void death()
    {
        EnemyPatrol patrol = enemy.GetComponent<EnemyPatrol>();
        patrol.moveSpeed = 0;
        animate.SetTrigger("death");
        await Task.Delay(1000);
        Destroy(enemy);
        await Task.Delay(300);
        //StartCoroutine(deathfade());
    }

    ///Future code written for future purposes that could not be finished in time for final presentation
    /*private IEnumerator deathfade()
    {

        float fade = spriteRenderer.color.a;
        Color current = spriteRenderer.color;

        while (spriteRenderer.color.a > 0)
        {
            fade -= 0.01f;
            current.a = fade;
            spriteRenderer.color = current;
            yield return new WaitForSeconds(0.05f);
        }
    }*/
}
