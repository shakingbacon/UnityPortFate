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
        //soundSource2 = gameObject.transform.FindChild("Sound 2").GetComponent<AudioSource>();
        //soundSource3 = gameObject.transform.FindChild("Sound 3").GetComponent<AudioSource>();
        //soundSource4 = gameObject.transform.FindChild("Sound 4").GetComponent<AudioSource>();
        //soundSource5 = gameObject.transform.FindChild("Sound 5").GetComponent<AudioSource>();
        //soundSource6 = gameObject.transform.FindChild("Sound 6").GetComponent<AudioSource>();
        //soundSourceList.Add(soundSource);
        //soundSourceList.Add(soundSource2);
        //soundSourceList.Add(soundSource3);
        //soundSourceList.Add(soundSource4);
        //soundSourceList.Add(soundSource5);
        //soundSourceList.Add(soundSource6);

    }


    public static void PlayMusic(int id)
    {
        bgmSource.clip = bgm[id];
        bgmSource.Play();
        return;
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
        soundDatabase.StartCoroutine(soundDatabase.MakeSound(id));
    }


}
