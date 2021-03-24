using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class void_script : MonoBehaviour
{
    public bool endingtriggered;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !endingtriggered)
        {
            other.GetComponent<player_movement>().restart();
        }
    }
}
