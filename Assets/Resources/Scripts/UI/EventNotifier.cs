using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventNotifier : MonoBehaviour {

    public static EventNotifier Instance { get; set; }

    Text eventTextPrefab;

    int MaximumTextCount { get { return 6; } }

    void Start()
    {
        Instance = gameObject.GetComponent<EventNotifier>();
        eventTextPrefab = Resources.Load<Text>("Prefabs/UI/Event Text");
    }

    public void MakeEventNotifier(string notify)
    {
        Text text = Instantiate(eventTextPrefab, gameObject.transform);
        text.transform.SetSiblingIndex(0);
        text.text = notify;
        if (transform.childCount > MaximumTextCount)
        {
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
        }
    }


}
