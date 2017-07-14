using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        Interact();
    }

    public virtual void Interact()
    {
        Debug.Log("touch object");
    }
	    
}
