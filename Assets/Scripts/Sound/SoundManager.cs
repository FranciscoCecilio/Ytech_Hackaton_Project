using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

// Used in all menus. These managers pass on from scene to scene. They are spawned in Main Menu and 1st Exercise scene (2 different songs for each menu)
public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    List<AudioSource> allSources;
    public string musicToPlayOnStart; 
    
    void Start()
    {
        allSources = new List<AudioSource>();
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            // Add audiosource to list
            allSources.Add(s.source);

        }
        Play(musicToPlayOnStart);
    }

    public Sound GetSound(string name){
        Sound s =  Array.Find(sounds, sound => sound.name == name);
        return s;
    }

    public void Play(string name){
        Sound s = GetSound(name);
        if( s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void PlayOneShot(string name){
        Sound s = GetSound(name);
        if( s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.PlayOneShot(s.clip);
    }
}
