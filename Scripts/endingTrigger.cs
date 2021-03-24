using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<void_script>().endingtriggered = true;
            sound_manager.instance.allFalse();
            transition.instance.transanim.SetTrigger("fadeout_ending");
            game_manager.instance.neglectPause = true;
            // Debug.Log(Heart_manager.instance.getTotalHeart());
            // Debug.Log(Heart_manager.instance.getTotalKill());
            respawn_manager.instance.resetSpawnpos();
        }
    }
}
