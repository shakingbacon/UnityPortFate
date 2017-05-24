using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour {

    public Transform prefabTransform;
    public static List<Transform> prefabs = new List<Transform>();
	// Use this for initialization
	void Start () {
        prefabTransform = gameObject.transform;
        foreach (Transform prefab in Resources.LoadAll<Transform>("Prefabs"))
        {
            prefabs.Add(prefab);
        }
	}
	
}
