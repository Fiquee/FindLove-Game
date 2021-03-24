using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuResume : MonoBehaviour
{
    public Animator transanim;
    public void ResumeGame()
    {
        scene_manager.instance.Load_Scene("InGame");
    }

    public void activeTransition()
    {
        sound_manager.instance.Play("button");
        sound_manager.instance.allFalse();
        transanim.SetTrigger("fadeoutresume");
    }

    private void Update()
    {
        if (scene_manager.instance.played)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
