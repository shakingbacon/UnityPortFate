using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class NewItemDatabase : MonoBehaviour {

    public static NewItemDatabase Instance { get; set; }
    private List<NewItem> Items { get; set; }

	// Use this for initialization
	void Awake () {
		if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        BuildDatabase();
	}
	
	private void BuildDatabase()
    {
        Items = JsonConvert.DeserializeObject<List<NewItem>>(Resources.Load<TextAsset>("JSON/Items").ToString());
        Debug.Log(Items[0].Stats[0].StatName);
    }

    public NewItem GetItem(string itemSlug)
    {
        foreach(NewItem item in Items)
        {
            if (item.ObjectSlug == itemSlug)
            {
                return item;
            }
        }
        Debug.LogWarning("COULDNT FIND ITEM: " + itemSlug);
        return null;
    }

}
