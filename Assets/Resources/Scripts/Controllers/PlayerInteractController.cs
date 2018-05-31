using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractController : MonoBehaviour {

    public static PlayerInteractController Instance { get; set; }
    bool CanInteract {get;set;}
    public GameObject interactNotifier;
    public Text interactNotifierKey, interactWhat;

    KeyCode interactKey;
    public Interactable CurrentInteractable { get; set; }

    void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

        void Update()
    {
        if (CanInteract)
        {
            if (Input.GetKeyDown(interactKey))
            {
                CurrentInteractable.Interact();
            }
        }
    }

    public void ShowInteractNotifier(bool yes)
    {
        interactNotifier.SetActive(yes);
        CanInteract = yes;
    }

    public void ShowInteractNotifier(bool yes, string key)
    {
        interactNotifier.SetActive(yes);
        interactWhat.text = "Interact";
        CanInteract = yes;
        interactNotifierKey.text = key;
        interactKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
    }


    public void ShowInteractNotifier(bool yes, string key, string what)
    {
        interactNotifier.SetActive(yes);
        interactWhat.text = what;
        CanInteract = yes;
        interactNotifierKey.text = key;
        interactKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);
    }

}
