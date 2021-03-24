using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_enemy : MonoBehaviour
{

    public float speed;
    public Transform startpos;
    // public GameObject die_efx;
    private GameObject player;
    private SpriteRenderer rend;
    private Vector2 target;
    private bool isChasing;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!rend.isVisible)
        {
            return;
        }
        if (isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            if (startpos != null)
            {
                if (transform.position != startpos.position)
                {
                    transform.position = Vector2.MoveTowards(transform.position, startpos.position, speed * Time.deltaTime);
                }
                else
                {
                    transform.position = startpos.position;
                }
            }
        }
    }

    public void startChase()
    {
        isChasing = true;
    }

    public void stopChase()
    {
        isChasing = false;
    }

    // public void hurt()
    // {
    //     //SFX (explosion sfx)
    //     GameObject effect = Instantiate(die_efx, transform.position, Quaternion.identity);
    //     Destroy(effect, 3f);
    //     Destroy(gameObject);
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<player_movement>().restart();
        }
    }
}
