using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // This function is called when the player enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the other collider is tagged as the player
        if (other.CompareTag("Player"))
        {
            // Destroy the player game object
            Destroy(other.gameObject);
        }
    }
}
