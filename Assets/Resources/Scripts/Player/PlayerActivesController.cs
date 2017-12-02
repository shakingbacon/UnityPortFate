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
        SkillActiveEvents.OnDamageSkillHitEnemy += Test;
    }

    Damage Test(Damage dmg)
    {
        return dmg;
    }

    public void AddActive(Skill skill)
    {
        ActiveHolder holder = Instantiate(activeHolderPrefab, activesPanel.transform);
        holder.activeSkill = skill;
        holder.SetTimeLeft(skill.skillActiveDuration);
        holder.activeImage.transform.localScale = new Vector3(1, 1, 1);
        SkillActiveEffects.GetSkillActiveEffect(skill.skillID);
    }
	
    public void CheckActivesUsage()
    {
        foreach (Transform holder in activesPanel.transform)
        {
            ActiveHolder active = holder.GetComponent<ActiveHolder>();
        }
    }

    public void EndActive(int id)
    {
        foreach (Transform holder in activesPanel.transform)
        {
            ActiveHolder active = holder.GetComponent<ActiveHolder>();
            print(active.activeSkill.skillName);
            if (active.activeSkill.skillID == id)
            {
                Destroy(active.gameObject);
                return;
            }
        }
    }


}
