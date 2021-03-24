using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStartnewgame : MonoBehaviour
{

    public Animator transanim;
    public void startNewGame()
    {
        scene_manager.instance.played = true;
        scene_manager.instance.Load_Scene_NewGame("OpeningCutScene"); //later change to opening cutscene
    }

    public void activeTransition()
    {
        sound_manager.instance.Play("button");
        sound_manager.instance.allFalse();
        transanim.SetTrigger("fadeout");
    }
}
