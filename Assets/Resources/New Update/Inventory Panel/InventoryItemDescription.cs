using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryItemDescription : MonoBehaviour
{

    [HideInInspector] Text mingzi, desc, type, stats, action;

    private void Start()
    {
        mingzi = transform.Find("Name").GetComponent<Text>();
        desc = transform.Find("Description").GetComponent<Text>();
        type = transform.Find("Type").GetComponent<Text>();
        stats = transform.Find("Stats").GetComponent<Text>();
        action = transform.Find("Action").GetComponent<Text>();
    }

    public void SetDescription(Item item)
    {
        gameObject.SetActive(true);
        action.gameObject.SetActive(true);
        mingzi.text = item.name;
        desc.text = item.Description + "\nCost: $" + item.Cost;
        type.text = string.Format("({0})", item.ItemType);
        stats.text = "";
        if (item.Stats != null)
        {
            foreach (BaseStat stat in item.Stats.Stats)
            {
                if (stat.FinalValue != 0)
                    if (stat.FinalValue > 0) stats.text += string.Format("{0}: +{1}\n", stat.Type, stat.BaseValue);
                    else stats.text += string.Format("{0}: {1}\n", stat.Type, stat.BaseValue);

            }
        }
        if (item is Weapon) action.text = "Click to wield";

    }




}
