using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDescription : MonoBehaviour
{
    [HideInInspector] private Text _action;
    [HideInInspector] private Text _desc;

    [HideInInspector] private Text _name;
    [HideInInspector] private Text _stats;
    [HideInInspector] private Text _type;

    private void Start()
    {
        _name = transform.Find("Name").GetComponent<Text>();
        _desc = transform.Find("Description").GetComponent<Text>();
        _type = transform.Find("Type").GetComponent<Text>();
        _stats = transform.Find("Stats").GetComponent<Text>();
        _action = transform.Find("Action").GetComponent<Text>();
    }

    public void SetDescription(Item item, string act, int x)
    {
        transform.localPosition = new Vector3(x, transform.position.y);
        gameObject.SetActive(true);
        _action.gameObject.SetActive(true);
        _name.text = item.name;
        _desc.text = item.Description + "\nCost: $" + item.Cost;
        _type.text = $"({item.ItemType})";
        _stats.text = "";
        if (item.Stats != null)
            foreach (var stat in item.Stats.Stats)
            {
                if (stat.FinalValue == 0) continue;
                if (stat.FinalValue > 0) _stats.text += $"{stat.Type}: +{stat.BaseValue}\n";
                else _stats.text += $"{stat.Type}: {stat.BaseValue}\n";
            }
        _action.text = act;
    }
}