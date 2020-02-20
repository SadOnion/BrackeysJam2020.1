﻿using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    [SerializeField]bool muted;
    [Space]
    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = muted?0:s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
       // Play("Theme");
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s?.source.Play();
    }
    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s.source.isPlaying;
    }
    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s?.source.Stop();
    }
}