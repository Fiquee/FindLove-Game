using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{

    public float speed;
    public float movedir;
    public bool facingright;
    public GameObject die_efx;
    private SpriteRenderer rend;
    private int health = 3;
    private float movetemp;
    private Animator enemyanim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        enemyanim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rend.isVisible)
        {
            return;
        }
        else
        {
            if (movedir > 0 && !facingright)
            {
                flip();
            }
            if (movedir < 0 && facingright)
            {
                flip();
            }
            rb.velocity = new Vector2(movedir * speed, rb.velocity.y);
            if (movedir != 0)
            {
                enemyanim.SetBool("walking", true);
            }
            else
            {
                enemyanim.SetBool("walking", false);
            }
        }
    }

    public IEnumerator waitToflip()
    {
        movetemp = movedir;
        movedir = 0;
        yield return new WaitForSeconds(2f);
        movedir = movetemp;
        flip();
    }

    public void flip()
    {
        facingright = !facingright;
        movedir *= -1;
        // GetComponentInChildren<Wand>().flipoffset();
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        // transform.Rotate(0f, 180f, 0f);
    }

    public void hurt()
    {
        health--;
        if (health == 2)
        {
            sound_manager.instance.Play("enemy_hurt");
            enemyanim.SetTrigger("change1");
            speed = 3f;
        }
        else if (health == 1)
        {
            sound_manager.instance.Play("enemy_hurt");
            enemyanim.SetTrigger("change2");
            speed = 4f;
        }
        else
        {
            die();
        }
    }

    public void die()
    {
        sound_manager.instance.Play("enemy_die");
        Heart_manager.instance.increaseKill();
        GameObject effect = Instantiate(die_efx, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<player_movement>().restart();
        }
    }
}
