using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDatabase : MonoBehaviour
{
    private readonly List<AudioClip> _bgm = new List<AudioClip>();
    private readonly List<AudioClip> _sounds = new List<AudioClip>();
    private AudioSource _bgmSource;
    public static SoundDatabase Instance { get; set; }

    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
        _bgmSource = transform.Find("BGM").GetComponent<AudioSource>();
        // add _bgm
        var bgmClips = Resources.LoadAll<AudioClip>("Game/Music/BGM");
        foreach (var file in bgmClips) _bgm.Add(file);
        // Add sounds
        var soundClips = Resources.LoadAll<AudioClip>("Game/Music/Sounds");
        foreach (var file in soundClips) _sounds.Add(file);
    }

    public void PlayMusic(int id)
    {
        _bgmSource.clip = _bgm[id];
        _bgmSource.Play();
    }

    public void PlayMusic(int id, bool loop)
    {
        _bgmSource.clip = _bgm[id];
        _bgmSource.loop = loop;
        _bgmSource.Play();
    }

    public void PauseMusic()
    {
        _bgmSource.Pause();
    }

    private IEnumerator MakeSound(int id)
    {
        var newSound = Instantiate(new GameObject(), transform);
        newSound.AddComponent<AudioSource>();
        var source = newSound.GetComponent<AudioSource>();
        source.clip = _sounds[id];
        yield return new WaitForSeconds(source.clip.length);
        Destroy(newSound.gameObject);
    }

    public void PlaySound(int id)
    {
        switch (id)
        {
            case -2:
                break;
            case -1:
                StartCoroutine(MakeSound(Random.Range(1, 8)));
                break;
            default:
                StartCoroutine(MakeSound(id));
                break;
        }
    }
}