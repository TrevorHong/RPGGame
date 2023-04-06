using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes the camera viewport always follow the player
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, this.transform.position.z);
    }
}
