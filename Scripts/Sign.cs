using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{

    public GameObject zbutton;
    public bool signIsactive;
    public bool isEnding;
    private bool inrange;
    private SpriteRenderer rend;
    [SerializeField] private Dialog dialog;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (!rend.isVisible)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z) && inrange && !signIsactive)
        {
            if (isEnding)
            {
                signIsactive = true;
                StartCoroutine(dialog_manager.instance.ShowDialog(dialog));
                GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>().stopMove();
            }
            else
            {
                signIsactive = true;
                StartCoroutine(sign_Manager.instance.ShowDialog(this.gameObject, dialog));
                GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>().stopMove();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inrange = true;
            zbutton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inrange = false;
            zbutton.SetActive(false);
        }
    }
}
