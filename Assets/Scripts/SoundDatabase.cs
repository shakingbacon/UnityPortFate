using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SoundDatabase : MonoBehaviour {

    public static SoundDatabase soundDatabase;
    public Transform sound;
    public static List<AudioClip> bgm = new List<AudioClip>();
    public static List<AudioClip> sounds = new List<AudioClip>();
    public static AudioSource bgmSource;
    public static List<AudioSource> soundSourceList = new List<AudioSource>();
    public static AudioClip previousMusic;


    void Start()
    {
        soundDatabase = gameObject.transform.GetComponent<SoundDatabase>();
        bgmSource = gameObject.transform.FindChild("BGM").GetComponent<AudioSource>();
        AudioClip[] bgmClips = Resources.LoadAll<AudioClip>("Music/BGM");
        foreach (var file in bgmClips)
        {
            bgm.Add(file);
        }
        //soundSource = gameObject.transform.FindChild("Sound").GetComponent<AudioSource>();
        AudioClip[] soundClips = Resources.LoadAll<AudioClip>("Music/Sounds");
        foreach (var file in soundClips)
        {
            sounds.Add(file);
        }
    }

    public static void PlayMusicPrevious()
    {
        bgmSource.clip = previousMusic;
        bgmSource.Play();
        return;
    }

    public static void PlayMusic(int id)
    {
        previousMusic = bgmSource.clip;
        bgmSource.clip = bgm[id];
        bgmSource.Play();
        return;
    }

    public static void PlayMusic(int id, bool loop)
    {
        previousMusic = bgmSource.clip;
        bgmSource.clip = bgm[id];
        bgmSource.loop = loop;
        bgmSource.Play();
        return;
    }

    public static void PauseMusic()
    {
        bgmSource.Pause();
    }

    public IEnumerator MakeSound(int id)
    {
        Transform newSound = Instantiate(sound, GameObject.FindGameObjectWithTag("Sound Database").transform);
        newSound.GetComponent<AudioSource>().clip = sounds[id];
        newSound.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(newSound.GetComponent<AudioSource>().clip.length);
        Destroy(newSound.gameObject);
        //Instantiate()
        //foreach(AudioSource source in soundSourceList)
        //{
        //    if (!source.isPlaying)
        //    {
        //        source.clip = sounds[id];
        //        source.Play();
        //        break;
        //    }
        //}
    }

    public static void PlaySound(int id)
    {
        if (id == -2)
        {

        }
        else if (id == -1)
        {
            soundDatabase.StartCoroutine(soundDatabase.MakeSound(Random.Range(1, 8)));
        }
        else
        {
            soundDatabase.StartCoroutine(soundDatabase.MakeSound(id));
        }
    }

}
