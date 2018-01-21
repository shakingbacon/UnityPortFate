using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActivesController : MonoBehaviour
{

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
        if (HasActive(skill.skillID)) EndActive(skill.skillID);
        ActiveHolder holder = Instantiate(activeHolderPrefab, activesPanel.transform);
        holder.activeSkill = skill;
        holder.activeImage.sprite = Resources.Load<Sprite>("Icons/Skills/" + skill.skillName);
        holder.SetTimeLeft(skill.skillActiveDuration);
        holder.activeImage.transform.localScale = new Vector3(1, 1, 1);

        SkillActiveEffects.GetSkillActiveEffect(skill.skillID);
    }

    //public void CheckActivesUsage(Skill skill)
    //{
    //    foreach (Transform holder in activesPanel.transform)
    //    {
    //        ActiveHolder active = holder.GetComponent<ActiveHolder>();
    //    }
    //}

    public bool HasActive(int id)
    {
        foreach (Transform holder in activesPanel.transform)
        {
            ActiveHolder active = holder.GetComponent<ActiveHolder>();
            if (active.activeSkill.skillID == id)
                return true;
        }
        return false;
    }

    public void EndActive(int id)
    {
        foreach (Transform holder in activesPanel.transform)
        {
            ActiveHolder active = holder.GetComponent<ActiveHolder>();
            //print(active.activeSkill.skillName);
            if (active.activeSkill.skillID == id)
            {
                SkillActiveEffects.RemoveSkillActiveEffect(id);
                Destroy(active.gameObject);
                return;
            }
        }
    }
}
