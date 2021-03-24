using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPos : MonoBehaviour
{
    public static RespawnPos instance;
    public GameObject prev_trigger;
    // private respawn_manager rm;

    // private void Awake()
    // {
    //     // if (instance == null)
    //     // {
    //     //     instance = this;
    //     // }
    //     // else
    //     // {
    //     //     Destroy(gameObject);
    //     //     return;
    //     // }
    //     DontDestroyOnLoad(gameObject);
    // }

    // private void Start()
    // {
    //     rm = FindObjectOfType<respawn_manager>();
    // }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // rm.setPosition(transform.position);
            respawn_manager.instance.setPosition(transform.position);
            if (prev_trigger != null)
            {
                prev_trigger.GetComponent<CamMoveTrigger>().isActivate = true;
            }

            // respawn_manager.instance.spawnpos.position = transform.position;
        }
    }
}
