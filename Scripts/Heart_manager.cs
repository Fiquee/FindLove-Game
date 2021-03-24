using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Heart_manager : MonoBehaviour
{
    private int number_of_heart;
    private int collected_heart;
    private int total_heart;
    private int number_of_kill;
    private int total_kill;
    public static Heart_manager instance;
    // Start is called before the first frame update
    private void Awake()
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
    void Update()
    {
        if (ui_manager.instance != null)
        {
            ui_manager.instance.UpdateText(number_of_heart.ToString());
        }

        // StartCoroutine(waitfivesecond());
    }

    // public IEnumerator waitfivesecond()
    // {
    //     yield return new WaitForSeconds(1f);
    //     Debug.Log("This is bullet : " + number_of_heart);
    //     Debug.Log("This is collected heart : " + collected_heart);
    //     Debug.Log("This is total heart : " + total_heart);
    //     Debug.Log("This is total kill : " + total_kill);
    // }

    public int getHeart()
    {
        return number_of_heart;
    }
    public int getTotalHeart()
    {
        return total_heart;
    }

    public int getTotalKill()
    {
        return total_kill;
    }

    public void increaseHeart()
    {
        number_of_heart += 3;
        // Debug.Log(number_of_heart);
    }

    public void increaseOneHeart()
    {
        number_of_heart++;
    }
    public void increaseCollectedHeart()
    {
        collected_heart++;
    }

    public void decreaseHeart()
    {
        number_of_heart--;
    }

    public void addTotalHeart()
    {
        // Debug.Log(number_of_heart);
        total_heart += collected_heart;
    }

    public void increaseKill()
    {
        number_of_kill++;
    }

    public void addTotalKill()
    {
        total_kill = total_kill + number_of_kill;
    }

    public void ResetKill()
    {
        number_of_kill = 0;
    }

    public void ResetTotalKill()
    {
        total_kill = 0;
    }

    public void ResetHeart()
    {
        number_of_heart = 0;
    }

    public void ResetTotalHeart()
    {
        total_heart = 0;
    }

    public void ResetCollectedHeart()
    {
        collected_heart = 0;
    }

    public void Reset()
    {
        Heart_manager.instance.ResetKill();
        Heart_manager.instance.ResetHeart();
        Heart_manager.instance.ResetCollectedHeart();
    }

    public void addTotal()
    {
        Heart_manager.instance.addTotalHeart();
        Heart_manager.instance.addTotalKill();
    }
}
