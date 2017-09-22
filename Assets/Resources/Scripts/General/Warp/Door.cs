using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Warp {

	// Use this for initialization
	void Start () {
        interactString = "Enter";
        GetComponent<Collider2D>().isTrigger = true;
    }
}
