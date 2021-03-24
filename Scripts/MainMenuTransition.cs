using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTransition : MonoBehaviour
{
    public void resumeTrans()
    {
        GameObject.FindObjectOfType<MainMenuResume>().ResumeGame();
    }

    public void newGameTrans()
    {
        GameObject.FindObjectOfType<MainMenuStartnewgame>().startNewGame();
    }
}
