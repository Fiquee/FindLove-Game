using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask whatisGround;
    public Transform feetpos;
    public GameObject jump_efx;
    public float checkradius;
    public float jumpforce;
    public float speed;
    public int start_extrajumps;
    private int extrajumps;
    private bool canmove;
    private float movedir;
    private bool facingright;
    private bool isGrounded;
    private bool prevGrounded;
    private Animator playeranim;



    void Start()
    {
        canmove = true;
        facingright = true;
        playeranim = gameObject.GetComponent<Animator>();
        if (respawn_manager.instance != null)
        {
            transform.position = respawn_manager.instance.getPosition();
        }
        // transform.position = respawn_manager.instance.spawnpos.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (canmove && !game_manager.instance.isPause)
        {
            if (Input.GetKeyDown(KeyCode.R))   // testing respawn pos
            {
                restart();
            }

            // Debug.Log("isGrounded : " + isGrounded);
            // Debug.Log("prevGrounded : " + prevGrounded);
            isGrounded = Physics2D.OverlapCircle(feetpos.position, checkradius, whatisGround);
            if (prevGrounded == false && isGrounded == true)
            {
                playeranim.SetTrigger("squishfall");
            }
            prevGrounded = isGrounded;
            if (Input.GetKeyDown(KeyCode.Space) && extrajumps > 0)
            {
                playeranim.SetTrigger("jump");
                Instantiate(jump_efx, feetpos.position, Quaternion.identity);
                sound_manager.instance.Play("player_jump");
                rb.velocity = Vector2.up * jumpforce;
                extrajumps--;
            }
            if (isGrounded)
            {
                extrajumps = start_extrajumps;
            }

            if (movedir > 0 && facingright == false)
            {
                flip();

            }
            if (movedir < 0 && facingright == true)
            {
                flip();
            }
        }
    }

    void FixedUpdate()
    {
        if (canmove)
        {
            movedir = Input.GetAxisRaw("Horizontal");

            if (movedir != 0)
            {
                playeranim.SetBool("walking", true);
            }
            else
            {
                playeranim.SetBool("walking", false);
            }
        }
        rb.velocity = new Vector2(movedir * speed, rb.velocity.y);
    }

    void flip()
    {
        facingright = !facingright;
        GetComponentInChildren<Wand>().flipoffset();
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        // transform.Rotate(0f, 180f, 0f);
    }

    public bool getfacingright()
    {
        return facingright;
    }
    public float getmovedir()
    {
        return movedir;
    }

    public void stopMove()
    {
        movedir = 0;
        playeranim.SetBool("walking", false);
        canmove = false;
    }

    public void startMove()
    {
        canmove = true;
    }

    public bool getcanmove()
    {
        return canmove;
    }

    public void restart()
    {
        // transform.position = respawn_manager.instance.spawnpos.position;
        sound_manager.instance.Play("player_die");
        if (sound_manager.instance.bossfight)
        {
            sound_manager.instance.bossfight = false;
            sound_manager.instance.ending = true;
        }
        scene_manager.instance.reloadScene();
    }
}
