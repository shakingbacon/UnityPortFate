using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour {
    Attributes stats;

	// Use this for initialization
	void Start () {
        stats = GetComponent<Player>().Stats;
	}
	
    public void ConsumeItem(Item item)
    {
        Debug.Log("Consumed: " + item.name);
        //GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Prefabs/Items/Consumables/" + item.ItemName));
        //if (item.ItemModifier)
        //{
        //    itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        //}
        //else
        //{
        //    itemToSpawn.GetComponent<IConsumable>().Consume();
        //}
    }

}
