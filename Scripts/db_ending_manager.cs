using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class db_ending_manager : MonoBehaviour
{
    public GameObject creature;
    public static db_ending_manager instance;
    public bool finish;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        dialog_manager.instance.DBEnding = true;
    }
    public IEnumerator spawn()
    {
        sound_manager.instance.allFalse();
        sound_manager.instance.Play("cam_shake");
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("shake");
        yield return new WaitForSeconds(2f);
        sound_manager.instance.Play("cam_shake");
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("shake");
        sound_manager.instance.PlayBossFightBGM();
        yield return new WaitForSeconds(3f);
        creature.SetActive(true);
    }

    private void Update()
    {
        if (finish)
        {
            finish = false;
            sound_manager.instance.allFalse();
            sound_manager.instance.ending = true;
            StartCoroutine(waitbeforeend());
        }
    }

    IEnumerator waitbeforeend()
    {
        yield return new WaitForSeconds(2f);
        transition.instance.transanim.SetTrigger("opacitytoblack");
    }
}
