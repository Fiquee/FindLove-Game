using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject impact;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground_enemy"))
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("shake");
            other.GetComponent<NormalEnemy>().hurt();
            explode();
        }
        // if (other.CompareTag("Fly_enemy"))
        // {
        //     GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("shake");
        //     other.GetComponent<Fly_enemy>().hurt();
        //     explode();
        // }
        if (other.CompareTag("bulletBorder") || other.CompareTag("platform"))
        {
            explode();
        }
    }

    public void explode()
    {
        Instantiate(impact, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void hitboss()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("shake");
        sound_manager.instance.Play("boss_hurt");
        explode();
    }
}
