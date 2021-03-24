using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldier : MonoBehaviour
{
    public GameObject arrow;
    public GameObject zbutton;
    public bool onlyOnce;
    private SpriteRenderer rend;
    private bool inRange;
    private bool ondialog;
    [SerializeField] private Dialog dialog;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            arrow.SetActive(true);
            zbutton.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            arrow.SetActive(false);
            zbutton.SetActive(false);
            inRange = false;
        }
    }

    void Update()
    {
        if (!rend.isVisible)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z) && inRange && !ondialog)
        {
            ondialog = true;
            StartCoroutine(dialog_manager.instance.ShowDialog(dialog));
            GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>().stopMove();
            if (onlyOnce)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public void setOndialog(bool flag)
    {
        ondialog = flag;
    }
}
