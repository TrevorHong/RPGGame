using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Changes the background to the Sky background upon entering the trigger
/// </summary>
public class SkyBackground : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject back = GameObject.Find("Backgrounds");
            Component[] trs = back.GetComponentsInChildren<Transform>(true);

            foreach(Transform trans in trs)
            {
                if (trans.name == "SkyBackground")
                {
                    trans.gameObject.SetActive(true);
                }
                else if (trans.name != "Backgrounds")
                {
                    trans.gameObject.SetActive(false);
                }
            }

        }
    }

}
