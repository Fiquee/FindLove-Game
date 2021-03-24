using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_heart : MonoBehaviour
{

    public GameObject[] nextHeart;
    public bool noBullet;
    [Header("Love is hard to carry")]
    public bool spawn_enemy;
    public GameObject enemy;

    [Header("Love is blind")]
    public bool low_sight;
    public float start_decrement_percent;
    private float decrement_percent;

    [Header("Love is time consuming")]
    public bool fake;
    public GameObject fakeRad;

    [Header("TrueLove")]
    public bool truelove;
    public GameObject platform;
    void Start()
    {
        decrement_percent = start_decrement_percent;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (nextHeart.Length != 0)
            {
                for (int i = 0; i < nextHeart.Length; i++)
                {
                    nextHeart[i].SetActive(true);
                }

            }
            if (!noBullet)
            {
                collectHeart();
            }
            if (spawn_enemy)
            {
                if (enemy != null)
                {
                    sound_manager.instance.Play("spawn_heart");
                    enemy.SetActive(true);
                }
            }
            else if (low_sight)
            {
                sound_manager.instance.Play("vision_heart");
                Vision_manager.instance.reduceVision(decrement_percent);
                // other.GetComponent<Vision_manager>().reduceVision(decrement_percent);
                decrement_percent *= 0.3f;
            }
            else if (fake)
            {
                Destroy(fakeRad);
            }
            else if (truelove)
            {
                platform.SetActive(true);
            }
        }
    }

    public void collectHeart()
    {
        if (!(low_sight || spawn_enemy))
        {
            sound_manager.instance.Play("collect_heart");
        }
        Heart_manager.instance.increaseHeart();
        Heart_manager.instance.increaseCollectedHeart();
        //play sound
        Destroy(gameObject);
    }
}
