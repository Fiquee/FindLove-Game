using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLove : MonoBehaviour
{

    public Transform[] teleportpos;
    public GameObject heart;
    public GameObject smoke;
    private int teleport_index = -1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && heart.GetComponent<Collectable_heart>().fake)
        {
            teleport();
        }
    }

    public void teleport()
    {
        if (teleport_index < teleportpos.Length - 1)
        {
            sound_manager.instance.Play("fake_heart");
            teleport_index++;
            // Debug.Log(teleport_index);
            Instantiate(smoke, transform.position, Quaternion.identity);
            heart.transform.position = teleportpos[teleport_index].position;
            this.transform.position = teleportpos[teleport_index].position;
        }
        else
        {
            return;
        }
    }
}
