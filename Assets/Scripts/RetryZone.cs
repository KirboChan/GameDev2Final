using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryZone : MonoBehaviour
{
    public ThisPlayer player;
    public Transform respawnPoint;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = respawnPoint.position;
        }
    }
}
