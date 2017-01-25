using UnityEngine;
using System.Collections;

public class Danger : MonoBehaviour {
    CameraFollow cameraFollow;
    public bool inBattle;
    GameObject player;
    GameObject playerClone = null;
    

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            DestroyImmediate(playerClone);
        }
	}

    void OnTriggerEnter2D()
    {
        inBattle = true;
        if (playerClone == null)
        {
            playerClone = Instantiate(player);
            playerClone.transform.position = new Vector3(playerClone.transform.position.x - 1, playerClone.transform.position.y, 0);
            cameraFollow.target = playerClone.transform;
            DestroyImmediate(playerClone.find<Equipment>());


        }
    }
}
