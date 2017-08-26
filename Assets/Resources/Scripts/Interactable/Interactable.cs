using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public string interactKey = "Z";
    public string interactString = "Interact";

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            EnterInteractionArea(player);
        }
    }

    void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            LeftInteractionArea(player);
        }
    }


    public virtual void EnterInteractionArea(Collider2D player)
    {
        player.GetComponent<PlayerInteractController>().CurrentInteractable = this;
        player.GetComponent<PlayerInteractController>().ShowInteractNotifier(true, interactKey, interactString);
    }

    public virtual void LeftInteractionArea(Collider2D player)
    {
        player.GetComponent<PlayerInteractController>().ShowInteractNotifier(false);
    }


    public virtual void Interact()
    {
        Debug.Log("pressed interaction key");
    }
	    
}
