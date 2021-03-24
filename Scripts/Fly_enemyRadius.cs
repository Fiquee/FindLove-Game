using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_enemyRadius : MonoBehaviour
{

    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (enemy != null)
            {
                enemy.GetComponent<Fly_enemy>().startChase();
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (enemy != null)
            {
                enemy.GetComponent<Fly_enemy>().stopChase();
            }
        }
    }
}
