using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cutscene_manager : MonoBehaviour
{
    [SerializeField] private GameObject TextBox;
    [SerializeField] private TextMeshProUGUI cutscene_text;
    [SerializeField] private GameObject zbutton;
    [SerializeField] private Dialog dialog;
    public float typespeed;
    private int currentline = 0;
    private bool isTyping;
    private bool skip;
    private bool ondialog;

    public static cutscene_manager instance { get; private set; }

    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(ShowDialog(dialog));
    }
    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForSeconds(0.2f); //this is if happen in interaction with NPC
        this.dialog = dialog;
        ondialog = true;
        TextBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[currentline]));
    }

    public IEnumerator TypeDialog(string dialog)
    {
        isTyping = true;
        zbutton.SetActive(false);
        cutscene_text.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            sound_manager.instance.Play("opening_text");
            if (skip)
            {
                break;
            }
            cutscene_text.text += letter;
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
                TextBox.SetActive(false);
                StartCoroutine(waitbeforeStartGame());
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z) && isTyping == true && ondialog == true)
        {
            skip = true;
            cutscene_text.text = "";
            cutscene_text.text += dialog.Lines[currentline];

        }
    }

    public IEnumerator waitbeforeStartGame()
    {
        yield return new WaitForSeconds(1f);
        sound_manager.instance.allFalse();
        sound_manager.instance.level = true;
        scene_manager.instance.Load_Scene_NewGame("InGame"); //later change to opening cutscene
    }
}
