using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn_manager : MonoBehaviour
{

    public static respawn_manager instance;
    private int cam_index;
    // public Transform spawnpos;
    private Vector2 spawnpos;
    private Vector2 initial_spawnpos;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            spawnpos = getInitialSpawnpos();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public Vector2 getPosition()
    {
        return spawnpos;
    }

    public void setPosition(Vector2 pos)
    {
        spawnpos = pos;
    }

    public int getCamPosition()
    {
        return cam_index;
    }

    public void setCamPosition(int index)
    {
        cam_index = index;
    }

    public void resetSpawnpos()
    {
        spawnpos = getInitialSpawnpos();
    }

    public Vector2 getInitialSpawnpos()
    {
        return new Vector2(-14.6f, -6);
    }
}
