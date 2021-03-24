using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sign_Manager : MonoBehaviour
{
    [SerializeField] private GameObject DialogBox;
    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private GameObject zbutton;
    private GameObject currentsign;
    private Dialog dialog;
    private int currentline = 0;
    public float typespeed;
    private bool isTyping;
    private bool skip;
    private bool ondialog;

    public static sign_Manager instance { get; private set; }

    void Awake()
    {
        instance = this;
    }
    public IEnumerator ShowDialog(GameObject sign, Dialog dialog)
    {
        yield return new WaitForSeconds(0.2f); //this is if happen in interaction with NPC
        currentsign = sign;
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
            sound_manager.instance.Play("sign");
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
                StartCoroutine(wait());
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
        currentsign.GetComponent<Sign>().signIsactive = false;
    }
}
