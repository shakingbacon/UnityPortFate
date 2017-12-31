using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelBarController : MonoBehaviour {

    public static ChannelBarController Instance { get; set; }

    ChannelBar channelBarPrefab;

    void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        channelBarPrefab = Resources.Load<ChannelBar>("Prefabs/UI/Channel Bar/Channel Bar UI");
    }

    public void MakeChannelBar(string name, float time)
    {
        print("cool");
        ChannelBar channelBar = Instantiate(channelBarPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        channelBar.skillName.text = name;
        channelBar.Duration = time;
    }
}
