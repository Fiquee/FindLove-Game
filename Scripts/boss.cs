using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

    [SerializeField] private float bulletspeed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float Health;
    [SerializeField] private float start_tpTime;
    [SerializeField] private Transform[] tp_position;
    [SerializeField] private GameObject die_efx;
    public bool invisible;
    public bool isDead;
    private int current_tpPos_index;
    private bool phase2;
    private bool phase3;
    private CircleCollider2D hitbox;
    private Animator bossanim;
    private float tpTime;
    private Vector3 startpoint;
    private bool stopcount;
    private const float radius = 1f;
    // Start is called before the first frame update
    void Start()
    {
        startpoint = transform.position;
        current_tpPos_index = 0;
        bossanim = GetComponent<Animator>();
        tpTime = start_tpTime;
        hitbox = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        startpoint = transform.position;
        if (Health <= 100 && !phase2)
        {
            phase2 = true;
            start_tpTime = start_tpTime * 0.5f;
            tpTime = start_tpTime;
        }
        if (Health <= 50 && !phase3)
        {
            phase3 = true;
            start_tpTime = start_tpTime * 0.5f;
            tpTime = start_tpTime;
        }
        if (Health <= 0)
        {
            die();
        }
        if (tpTime <= 0)
        {
            beInvisible();
            bossanim.SetTrigger("teleport");
            tpTime = start_tpTime;
            stopcount = true;
        }
        else if (tpTime > 0 && !stopcount)
        {
            tpTime -= Time.deltaTime;
        }
    }

    public void teleport() // called by animator
    {
        int rand = RandNumber(current_tpPos_index);
        current_tpPos_index = rand;
        transform.position = tp_position[rand].position;
    }

    int RandNumber(int current_index)
    {
        int newIndex = Random.Range(0, tp_position.Length);
        while (newIndex == current_index)
        {
            newIndex = Random.Range(0, tp_position.Length);
        }
        return newIndex;
    }

    public void circularattack(int _numberofBullet)
    {
        //SFX
        float angleStep = 360f / _numberofBullet;
        float angle = 0f;

        for (int i = 0; i < _numberofBullet; i++)
        {
            float bulletXposition = startpoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float bulletYposition = startpoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 bulletvector = new Vector3(bulletXposition, bulletYposition, 0f);
            Vector3 bulletmovedirection = (bulletvector - startpoint).normalized * bulletspeed;
            GameObject obj = Instantiate(bullet, startpoint, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletmovedirection.x, bulletmovedirection.y);

            angle += angleStep;
        }
        sound_manager.instance.Play("boss_shoot");
    }

    public void beInvisible()
    {
        invisible = true;
    }

    public void beSolid() //will be call by animator
    {
        invisible = false;
        stopcount = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!invisible && other.CompareTag("player_bullet"))
        {
            hurt();
            other.GetComponent<bullet>().hitboss();
        }
    }

    void hurt()
    {
        Health -= 10;
    }

    public void die()
    {
        isDead = true;
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Wand>().infinite = false;
        beInvisible();
        bossanim.SetTrigger("bossdie");
    }

    public void destroyObj()
    {
        sound_manager.instance.Play("boss_die");
        Instantiate(die_efx, transform.position, Quaternion.identity);
        db_ending_manager.instance.finish = true;
        Destroy(gameObject);
    }
}
