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
    }

    public NewItem GetItem(string itemName)
    {
        foreach(NewItem item in Items)
        {
            if (item.ItemName == itemName)
            {
                return item;
            }
        }
        Debug.LogWarning("COULDNT FIND ITEM: " + itemName);
        return null;
    }

}
