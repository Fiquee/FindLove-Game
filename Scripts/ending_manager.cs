using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending_manager : MonoBehaviour
{
    [Header("Dilemma Ending")]
    public GameObject lover;

    [Header("Loyal")]
    public GameObject lover_2;

    [Header("Innocent Blur")]
    public GameObject lover_3;
    public GameObject soldier;

    [Header("Nothing to prove")]
    public GameObject sign;


    void Start()
    {
        if (Heart_manager.instance.getTotalHeart() == 29 && Heart_manager.instance.getTotalKill() == 16)
        {
            //dilemma ending
            lover.SetActive(true);
            dialog_manager.instance.isEnding1 = true;
        }
        else if (Heart_manager.instance.getTotalHeart() == 29 && Heart_manager.instance.getTotalKill() == 0)
        {
            //loyal ending
            lover_2.SetActive(true);
            dialog_manager.instance.isEnding2 = true;
        }
        else if (Heart_manager.instance.getTotalHeart() == 0 && Heart_manager.instance.getTotalKill() == 0)
        {
            //innocent blur
            lover_3.SetActive(true);
            soldier.SetActive(true);
            dialog_manager.instance.isEnding3 = true;
        }
        else
        {
            sign.SetActive(true);
            dialog_manager.instance.isEnding4 = true;
        }
    }
}
