using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveTrigger : MonoBehaviour
{
    public GameObject cam;
    public bool scaleBig;
    public bool scaleSmall;
    public bool isActivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isActivate)
        {
            sound_manager.instance.Play("next_level");
            isActivate = true;
            cam.GetComponent<CameraFollow>().changelevel(scaleBig, scaleSmall);
            Heart_manager.instance.addTotal();
            Heart_manager.instance.Reset();
            Vision_manager.instance.resetVision();
            // Debug.Log("Total heart is : " + Heart_manager.instance.getTotalHeart());
            // Debug.Log("Total kill is : " + Heart_manager.instance.getTotalKill());
            // other.GetComponent<Vision_manager>().resetVision();
            // Destroy(gameObject);
        }
    }
}
