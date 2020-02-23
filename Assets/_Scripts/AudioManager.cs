using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    [SerializeField]bool muted=false;
    [Space]
    public Sound[] sounds;
    public static AudioManager instance;
    public Sound[] steps;
    public Sound[] themes;
    public int newThemeEveryLevels=2;
    int previousThemeNum=0;
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
        foreach (Sound s in steps)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = muted?0:s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
         foreach (Sound s in themes)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = muted?0:s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        DontDestroyOnLoad(gameObject);
        
    }

    private void Start()
    {
       PlayTheme("Theme0");
    }
    public void PlayNextTheme(int sceneIndex)
    {
        int theme = sceneIndex/newThemeEveryLevels;
        theme = theme>=themes.Length?themes.Length-1:theme;
        if(!IsPlayingTheme("Theme"+theme))PlayTheme("Theme"+theme);
        
        
    }
    public void PlayTheme(string name)
    {
        foreach (var item in themes)
        {
            if(item.source.isPlaying)item.source.Stop();
        }
        Sound s = Array.Find(themes, sound => sound.name == name);
        s?.source.Play();
    }
    public bool IsPlayingTheme(string name)
    {
        Sound s = Array.Find(themes, sound => sound.name == name);
        return s.source.isPlaying;
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
    public void RandomStepSound()
    {
        int rand = UnityEngine.Random.Range(0,steps.Length);
        steps[rand].source.Play();
    }
    public void ChangeVolume(float vol)
    {
        GameObject[] sources = GameObject.FindGameObjectsWithTag("Trap");
        vol = Mathf.Clamp(vol,0,1f);
        foreach (var item in sounds)
        {
            item.source.volume = item.volume*vol;
        }
        foreach (var item in themes)
        {
            item.source.volume = item.volume*vol;
        }
        foreach (var item in sources)
        {
            item.GetComponent<AudioSource>().volume = vol*.03f;
        }
    }
}