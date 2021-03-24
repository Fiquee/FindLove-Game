using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{

    public Transform shootpos;
    public float bulletforce;
    public Vector3 offset;
    public Transform player;
    public GameObject bulletPrefab;
    public Camera cam;
    public Rigidbody2D rb;
    public bool infinite;
    public float start_reloadTime;
    private float reloadTime;
    private Vector2 mousepos;

    // Update is called once per frame
    void Update()
    {
        if (!game_manager.instance.isPause && GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>().getcanmove())
        {
            mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
            rb.position = player.position + offset;
            if ((Input.GetMouseButtonDown(0) && Heart_manager.instance.getHeart() > 0))
            {
                shoot();
            }
        }
        if (infinite)
        {
            if (reloadTime <= 0)
            {
                Reload();
                reloadTime = start_reloadTime;
            }
            else
            {
                reloadTime -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = mousepos - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void flipoffset()
    {
        offset.x *= -1;
    }

    public void shoot()
    {
        Heart_manager.instance.decreaseHeart();
        sound_manager.instance.Play("player_shoot");
        GameObject bullet = Instantiate(bulletPrefab, shootpos.position, shootpos.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootpos.up * bulletforce, ForceMode2D.Impulse);
    }

    public void Reload()
    {
        Heart_manager.instance.increaseOneHeart();
    }
}
