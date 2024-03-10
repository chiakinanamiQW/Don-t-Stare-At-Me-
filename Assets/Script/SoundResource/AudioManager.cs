using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] MusicSounds,SFXSounds;
    public AudioSource musicSource, sfxSource;
    public Slider MusicVolume;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("Theme");
        MusicVolume.value = musicSource.volume;
        MusicVolume.onValueChanged.AddListener(delegate { VolumeManger(); });
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFXSounds, x => x.Name == name);
        if (s == null)

        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void VolumeManger()
    {
        musicSource.volume = MusicVolume.value;
    }

    private void PlayMusic(string v)
    {
        Sound s=Array.Find(MusicSounds,x=>x.Name == v);
        {
            if(s == null)
            {
                Debug.Log("Can not Find");
            }
            else
            {
                musicSource.clip=s.clip;
                musicSource.Play();
            }
        }
    }
}
