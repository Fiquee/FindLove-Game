using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class sound_manager : MonoBehaviour
{
    public bool level;
    public bool mainmenu;
    public bool ending;
    public bool bossfight;
    public Sound[] sfx;
    public static sound_manager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sfx)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.sb;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (level && !checkIsPlaying("InGame"))
        {
            Stop("Theme");
            Stop("Ending");
            Stop("bossfight");
            Play("InGame");
        }
        else if (mainmenu && !checkIsPlaying("Theme"))
        {
            Stop("Ending");
            Stop("bossfight");
            Stop("InGame");
            Play("Theme");
        }
        else if (ending && !checkIsPlaying("Ending"))
        {
            Stop("Theme");
            Stop("bossfight");
            Stop("InGame");
            Play("Ending");
        }
        else if (bossfight && !checkIsPlaying("bossfight"))
        {
            Stop("Theme");
            Stop("InGame");
            Stop("Ending");
            Play("bossfight");
        }
    }
    public bool checkIsPlaying(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return false;
        }
        return s.source.isPlaying;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return;
        }
        s.source.Stop();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name); //find object in array by name
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return;
        }
        s.source.Pause();
    }

    public void unPause(string name)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return;
        }
        s.source.UnPause();
    }

    public void setVolume(string name, float vol)
    {
        Sound s = Array.Find(sfx, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name " + name + " is not found");
            return;
        }
        s.volume = vol;
        s.source.volume = s.volume;
    }
    public void PlayBossFightBGM()
    {
        bossfight = true;
    }

    public void allFalse()
    {
        mainmenu = false;
        ending = false;
        level = false;
        bossfight = false;
    }
}
