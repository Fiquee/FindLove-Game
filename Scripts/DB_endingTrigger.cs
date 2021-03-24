using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_endingTrigger : MonoBehaviour
{
    public GameObject platform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!platform.activeInHierarchy)
        {
            if (other.CompareTag("Player"))
            {
                FindObjectOfType<void_script>().endingtriggered = true;
                sound_manager.instance.allFalse();
                transition.instance.transanim.SetTrigger("fadeout_DBending");
                game_manager.instance.neglectPause = true;
                respawn_manager.instance.resetSpawnpos();
            }
        }
    }
}
