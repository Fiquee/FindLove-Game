using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_bullet : MonoBehaviour
{
    [SerializeField] private GameObject effects;

    private void Update()
    {
        if (GameObject.FindObjectOfType<boss>().isDead)
        {
            explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bulletBorder") || other.CompareTag("platform"))
        {
            explode();
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<player_movement>().restart();
        }
    }

    void explode()
    {
        sound_manager.instance.Play("boss_bulletefx");
        Instantiate(effects, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
