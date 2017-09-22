using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CurrentMap : MonoBehaviour {
    public static CurrentMap Instance { get; set; }

    [HideInInspector] public Transform area;
    [HideInInspector] public Transform enemies;

	// Use this for initialization
	void Start () {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        area = transform.FindChild("Area");
        enemies = transform.FindChild("Enemies");
    }

    public void WarpPlayerToMap(string mapName)
    {
        Transform currentMap = area.GetChild(0);
        currentMap.localScale = new Vector3(0, 0, 0);
        string fromMapName = currentMap.name;
        Map map = Instantiate(Resources.Load<Map>("Prefabs/Maps/" + mapName));
        map.name = map.name.Substring(0, map.name.Length - 7);
        SoundDatabase.PlayMusic(map.mapMusicID);
        map.transform.transform.SetParent(area);
        Vector3 goToPos = map.transform.FindChild("From Targets").FindChild(fromMapName).position;
        GameManager.player.transform.position = goToPos;
        Camera.main.transform.position = goToPos;
        DestroyAllEnemies();
    }

    public void DestroyAllEnemies()
    {
        foreach(Transform enemy in enemies)
        {
            IEnemy enemyComp = enemy.GetComponent<IEnemy>();
            if (enemyComp != null)
                enemy.GetComponent<IEnemy>().DestroySelf();
        }
    }
}
