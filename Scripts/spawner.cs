using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject[] flyenemy;
    public bool moveToPlayer;
    private GameObject player;
    public float speed;
    public static spawner instance;
    public Animator transanim;
    private bool activated;
    private bool startActivate;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (startActivate)
        {
            if (!activated)
            {
                activated = true;
                // Debug.Log(activated);
                StartCoroutine(startTransition());
            }
        }

    }

    public IEnumerator startTransition()
    {
        yield return new WaitForSeconds(2f);
        startActivate = false;
        activated = false;
        transanim.SetTrigger("opacitytoblack");
    }

    public void spawn()
    {
        StartCoroutine(startSpawn());
    }

    public IEnumerator startSpawn()
    {
        for (int i = 0; i < flyenemy.Length; i++)
        {
            yield return new WaitForSeconds(1f);
            //SFX
            flyenemy[i].SetActive(true);
        }
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < flyenemy.Length; i++)
        {
            flyenemy[i].GetComponent<Fly_enemy>().startChase();
        }
        startActivate = true;
    }
}
