using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transition : MonoBehaviour
{
    public Animator transanim;
    public GameObject[] credit;
    public static transition instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        transanim = GetComponent<Animator>();
        transanim.SetTrigger("fadein");
    }

    public void changeScene(string name)
    {
        scene_manager.instance.Load_Scene(name);
    }

    public void ending()
    {
        FindObjectOfType<void_script>().endingtriggered = false;
        scene_manager.instance.Load_Scene("Ending");
    }

    public void DBending()
    {
        FindObjectOfType<void_script>().endingtriggered = false;
        scene_manager.instance.Load_Scene("DBEnding");
    }

    public void AppearCredit()
    {
        if (dialog_manager.instance.isEnding1)
        {
            credit[0].SetActive(true);
        }
        else if (dialog_manager.instance.isEnding2)
        {
            credit[1].SetActive(true);
        }
        else if (dialog_manager.instance.isEnding3)
        {
            credit[2].SetActive(true);
        }
        else if (dialog_manager.instance.isEnding4)
        {
            credit[3].SetActive(true);
        }
        else if (dialog_manager.instance.DBEnding)
        {
            credit[4].SetActive(true);
        }
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(4f);
        scene_manager.instance.resetAll_Total();
        scene_manager.instance.played = false;
        game_manager.instance.neglectPause = false;
        sound_manager.instance.allFalse();
        changeScene("MainMenu");
    }
}
