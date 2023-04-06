using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int hitpoints = 3;

    SpriteRenderer spriteRenderer;
    public bool hit = false;
    public GameObject enemy;
    public Animator animate;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true && hitpoints > 0)
        {
            hitanimate();
        }
        if (hitpoints == 0)
        {
            death();
        }
    }
    async void hitanimate()
    {
        animate.SetBool("damage", true);
        await Task.Delay(1);
        animate.SetBool("damage", false);
        hit = false;
        await Task.Delay(1);

    }

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
