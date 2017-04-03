using UnityEngine;
using System.Collections;

public class Danger : MonoBehaviour {
    CameraFollow cameraFollow;
    GameManager manager;
    GameObject player;
    Vector3 playerPos, cameraPos;
    

	// Use this for initialization
	void Start () {
        manager  = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        //player = GameObject.FindGameObjectWithTag("Player");
        //cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButtonDown("Cancel"))
        //{
        //    DestroyImmediate(playerClone);
        //}
    }
    void OnTriggerEnter2D()
    {
        Battle.SetupBattle();
        ///
      ///if (playerClone == null)
        ///{
        ///    playerClone = Instantiate(player);
        ///    playerClone.transform.position = new Vector3(playerClone.transform.position.x - 1, playerClone.transform.position.y, 0);
        ///    cameraFollow.target = playerClone.transform;
        ///    Destroy(playerClone.transform.GetChild(2).gameObject);
        ///}
        ///
       
    }
}
