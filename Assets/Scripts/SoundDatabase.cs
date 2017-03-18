using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SoundDatabase : MonoBehaviour {
    public static List<AudioClip> bgm = new List<AudioClip>();
    public static List<AudioClip> sounds = new List<AudioClip>();
    public static AudioSource bgmSource;
    public static AudioSource soundSource;


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
    }


    public static void PlayMusic(int id)
    {
        bgmSource.clip = bgm[id];
        bgmSource.Play();
        return;
    }

    public static void PlaySound(int id)
    {
        soundSource.clip = sounds[id];
        soundSource.Play();
        return;
    }

}
