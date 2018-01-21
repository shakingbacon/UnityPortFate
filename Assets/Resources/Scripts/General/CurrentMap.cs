using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CurrentMap : MonoBehaviour {
    public static CurrentMap Instance { get; set; }

    public Transform area;
     public Transform enemies;
    public Transform pickupItems;

	// Use this for initialization
	void Start () {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void WarpPlayerToMap(string mapName)
    {
        Transform currentMap = area.GetChild(0);
        currentMap.localScale = new Vector3(0, 0, 0);
        string fromMapName = currentMap.name;
        Map map = Instantiate(Resources.Load<Map>("Prefabs/Maps/" + mapName + "/" + mapName));
        map.name = map.name.Substring(0, map.name.Length - 7);
        SoundDatabase.PlayMusic(map.mapMusicID);
        map.transform.transform.SetParent(area);
        Vector3 goToPos = map.transform.FindChild("From Targets").FindChild(fromMapName).position;
        GameManager.Instance.player.transform.position = goToPos;
        Camera.main.transform.position = goToPos;
        DestroyAllEnemies();
        DestroyAllItems();
    }

    public void DestroyAllEnemies()
    {
        foreach(Transform enemy in enemies)
        {
            Enemy lol = enemy.GetComponentInChildren<Enemy>();
            if (lol != null)
                enemy.GetComponentInChildren<Enemy>().DestroySelf();
        }
    }

    public void DestroyAllItems()
    {
        foreach (Transform item in pickupItems)
        {
            Destroy(item.gameObject);
        }
    }
}
