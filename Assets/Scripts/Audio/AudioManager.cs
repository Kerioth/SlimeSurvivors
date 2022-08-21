using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public string startSound;
    //public string backSound;
    public Sound[] sounds;
    Sound currentMusic;
    float currentVolume;
    float silentVolume;
    bool isPlayAbove;

    public static AudioManager Instance;

    void Awake()
    {
        Instance = this;
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        } 
    }

    private void Start()
    {
        Sound StartMusic = FindSound(startSound);
        StartMusic.source.Play();
        currentMusic = StartMusic;
        //PlaySound(backSound);
        isPlayAbove = false;
    }

    public void ChangeMusic(string name)
    {
        currentMusic.source.Stop();
        Sound newMusic = FindSound(name);
        newMusic.source.Play();
        currentMusic = newMusic;
    }

    public void PlayAbove(string name, bool isPlay)
    {
        if (isPlay)
        {
            isPlayAbove = true;
            currentVolume = currentMusic.source.volume;
            currentMusic.source.volume = 0f;
            PlaySound(name);
        }
        else if(isPlayAbove)
        {
            StopSound(name);
            currentMusic.source.volume = currentVolume;
            isPlayAbove = false;
        }
    }

    public void SilentMusic(string name, bool silent)
    {
        if (silent)
        {
            Sound silentMusic = FindSound(name);
            silentVolume = silentMusic.source.volume;
            silentMusic.source.volume = 0f;
        }
        else
        {
            Sound silentMusic = FindSound(name);
            silentMusic.source.volume = silentVolume;
        }
    }

    public void PlaySound(string name)
    {
        Sound soundToPlay = FindSound(name);
        if (soundToPlay == null) return;
        soundToPlay.source.Play();
    }

    public void PlaySound(Sound name)
    {
        name.source.Play();
    }

    public void PlayRandomSound(Sound[] sounds)
    {
        int index = UnityEngine.Random.Range(0, sounds.Length);
        sounds[index].source.Play();
    }

    public void StopSound(string name)
    {
        Sound soundToPlay = FindSound(name);
        if (soundToPlay == null) return;
        soundToPlay.source.Stop();
    }


    Sound FindSound(string name)
    {
        Sound lookingSound = Array.Find(sounds, sound => sound.name == name);
        return lookingSound;
    }
}
