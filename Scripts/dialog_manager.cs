using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialog_manager : MonoBehaviour
{
    [SerializeField] private GameObject DialogBox;
    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private GameObject zbutton;
    private Dialog dialog;
    private int currentline = 0;
    public float typespeed;
    public bool isEnding1;
    public bool isEnding2;
    public bool isEnding3;
    public bool isEnding4;
    public bool DBEnding;
    private bool isTyping;
    private bool skip;
    private bool ondialog;

    public static dialog_manager instance { get; private set; }

    void Awake()
    {
        instance = this;
    }
    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForSeconds(0.2f); //this is if happen in interaction with NPC
        this.dialog = dialog;
        ondialog = true;
        DialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[currentline]));
    }

    public IEnumerator TypeDialog(string dialog)
    {
        isTyping = true;
        zbutton.SetActive(false);
        DialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            if (isEnding3)
            {
                sound_manager.instance.Play("knight");
            }
            else if (isEnding4)
            {
                sound_manager.instance.Play("sign");
            }
            else
            {
                sound_manager.instance.Play("lover");
            }
            if (skip)
            {
                break;
            }
            DialogText.text += letter;
            yield return new WaitForSeconds(typespeed);
        }
        zbutton.SetActive(true);
        isTyping = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isTyping == false && ondialog == true)
        {
            skip = false;
            currentline++;
            if (currentline < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentline]));
            }
            else
            {
                currentline = 0;
                ondialog = false;
                DialogBox.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>().startMove();
                if (FindObjectOfType<Lover>() != null)
                {
                    StartCoroutine(wait());
                }
                if (FindObjectOfType<soldier>() != null)
                {
                    FindObjectOfType<soldier>().setOndialog(false);
                }
                if (isEnding1)
                {
                    spawner.instance.spawn();
                }
                else if (DBEnding)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Wand>().infinite = true;
                    StartCoroutine(db_ending_manager.instance.spawn());
                }
                else if (isEnding2 || isEnding3 || isEnding4)
                {
                    transition.instance.transanim.SetTrigger("opacitytoblack");
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z) && isTyping == true && ondialog == true)
        {
            skip = true;
            DialogText.text = "";
            DialogText.text += dialog.Lines[currentline];

        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<Lover>().setOndialog(false);
    }
}
