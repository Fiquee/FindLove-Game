using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{

    public static game_manager instance;
    public bool isPause;
    public bool neglectPause;
    public GameObject pauseMenu;

    private void Awake()
    {
        instance = this;
    }

    // private void Start()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //     }
    // }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !neglectPause)
        {
            if (!isPause)
            {
                isPause = true;
                pause();
            }
            else if (isPause)
            {
                isPause = false;
                resume();
            }
        }

    }

    public void pause()
    {
        sound_manager.instance.Play("pause");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resume()
    {
        sound_manager.instance.Play("pause");
        notPause();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void notPause()
    {
        isPause = false;
        Time.timeScale = 1f;
    }

    public void goMainMenu()
    {
        sound_manager.instance.Play("button");
        notPause();
        scene_manager.instance.QuitGame();
    }
}
