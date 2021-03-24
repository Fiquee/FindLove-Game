using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    public static scene_manager instance;
    public bool played;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void reloadScene()
    {
        resetAll();
        // FindObjectOfType<Vision_manager>().resetVision();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Load_Scene(string name) //later will be called after transition animation ends
    {
        switch (name)
        {
            case ("InGame"):
                sound_manager.instance.level = true;
                break;
            case ("MainMenu"):
                sound_manager.instance.mainmenu = true;
                break;
            case ("OpeningCutScene"):
            case ("Ending"):
            case ("DBEnding"):
                sound_manager.instance.ending = true;
                break;
        }

        SceneManager.LoadScene(name);
        // Debug.Log("this is total heart" + Heart_manager.instance.getTotalHeart());
        // Debug.Log("this is total kill" + Heart_manager.instance.getTotalKill());
    }
    public void Load_Scene_NewGame(string name)
    {
        resetAll_Total();
        Load_Scene(name); //openingcutscene //later delete
    }

    public void QuitGame()
    {
        resetAll();
        sound_manager.instance.allFalse();
        transition.instance.transanim.SetTrigger("fadeout");
        // SceneManager.LoadScene(name); //later delete
    }

    public void resetAll()
    {
        Heart_manager.instance.ResetHeart();
        Heart_manager.instance.ResetKill();
        Heart_manager.instance.ResetCollectedHeart();
        Vision_manager.instance.resetVision();
    }

    public void resetAll_Total()
    {
        Heart_manager.instance.ResetHeart();
        Heart_manager.instance.ResetKill();
        Heart_manager.instance.ResetCollectedHeart();
        // Vision_manager.instance.resetVision();
        Heart_manager.instance.ResetTotalHeart();
        Heart_manager.instance.ResetTotalKill();
        respawn_manager.instance.setCamPosition(0);
        respawn_manager.instance.resetSpawnpos();
        dialog_manager.instance.isEnding1 = false;
        dialog_manager.instance.isEnding2 = false;
        dialog_manager.instance.isEnding3 = false;
        dialog_manager.instance.isEnding4 = false;
        dialog_manager.instance.DBEnding = false;
    }
}
