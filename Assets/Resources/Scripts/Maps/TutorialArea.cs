using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialArea : MonoBehaviour
{
    public static bool questComplete = false;

    static GameObject hometownWarp;

    void Start()
    {
        hometownWarp = transform.Find("To Hometown").gameObject;
        if (questComplete)
            OpenHometownWarp();        
    }

    public static void OpenHometownWarp()
    {
        hometownWarp.SetActive(true);
    }
}
