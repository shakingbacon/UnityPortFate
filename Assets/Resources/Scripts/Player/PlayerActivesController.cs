using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivesController : MonoBehaviour {

    public static PlayerActivesController Instance;
    public GameObject activesPanel;
    public ActiveHolder activeHolderPrefab;

    void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void AddActive(Skill skill)
    {
        ActiveHolder holder = Instantiate(activeHolderPrefab, activesPanel.transform);
        holder.SetTimeLeft(skill.skillActiveDuration);
        holder.activeImage.transform.localScale = new Vector3(1, 1, 1);

    }
	


}
