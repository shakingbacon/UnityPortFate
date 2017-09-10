using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CurrentMap : MonoBehaviour {
    public static CurrentMap Instance { get; set; }

    public Transform area;
    public Transform enemies;


	// Use this for initialization
	void Start () {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        area = transform.FindChild("Area");
        enemies = transform.FindChild("Enemies");
    }

    public void WarpPlayerToMap(string mapName, int musicid)
    {
        SoundDatabase.PlayMusic(musicid);
        Transform currentMap = area.GetChild(0);
        currentMap.localScale = new Vector3(0, 0, 0);
        string fromMapName = currentMap.name;
        Transform map = Instantiate(Resources.Load<Transform>("Prefabs/Maps/" + mapName));
        map.transform.transform.SetParent(area);
        Vector3 goToPos = map.FindChild("From Targets").FindChild(fromMapName).position;
        GameManager.player.transform.position = goToPos;
        Camera.main.transform.position = goToPos;
        DestroyAllEnemies();
    }

    public void DestroyAllEnemies()
    {
        foreach(Transform enemy in enemies)
        {
            enemy.GetComponent<IEnemy>().DestroySelf();
        }
    }
}
