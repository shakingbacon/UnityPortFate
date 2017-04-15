using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SoundDatabase : MonoBehaviour {
    public static List<AudioClip> bgm = new List<AudioClip>();
    public static List<AudioClip> sounds = new List<AudioClip>();
    public static AudioSource bgmSource;
    public static AudioSource soundSource;
    public static AudioSource soundSource2;
    public static AudioSource soundSource3;
    public static AudioSource soundSource4;
    public static List<AudioSource> soundSourceList = new List<AudioSource>();


    void Start()
    {
        bgmSource = gameObject.transform.FindChild("BGM").GetComponent<AudioSource>();
        AudioClip[] bgmClips = Resources.LoadAll<AudioClip>("Music/BGM");
        foreach (var file in bgmClips)
        {
            bgm.Add(file);
        }
        soundSource = gameObject.transform.FindChild("Sound").GetComponent<AudioSource>();
        AudioClip[] soundClips = Resources.LoadAll<AudioClip>("Music/Sounds");
        foreach (var file in soundClips)
        {
            sounds.Add(file);
        }
        soundSource2 = gameObject.transform.FindChild("Sound 2").GetComponent<AudioSource>();
        soundSource3 = gameObject.transform.FindChild("Sound 3").GetComponent<AudioSource>();
        soundSource4 = gameObject.transform.FindChild("Sound 4").GetComponent<AudioSource>();
        soundSourceList.Add(soundSource);
        soundSourceList.Add(soundSource2);
        soundSourceList.Add(soundSource3);
        soundSourceList.Add(soundSource4);

    }


    public static void PlayMusic(int id)
    {
        bgmSource.clip = bgm[id];
        bgmSource.Play();
        return;
    }

    public static void PlaySound(int id)
    {
        bool didPlay = false;
        foreach(AudioSource source in soundSourceList)
        {
            if (!source.isPlaying)
            {
                source.clip = sounds[id];
                source.Play();
                didPlay = true;
                break;
            }
        }
        if (!didPlay)
        {
            soundSource.Play();
        }
    }

}
