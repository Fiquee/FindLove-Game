using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyborder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground_enemy"))
        {
            other.GetComponent<NormalEnemy>().StartCoroutine("waitToflip");
        }
    }
}
