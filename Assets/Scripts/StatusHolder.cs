using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusHolder : MonoBehaviour {

    public Skill skill;
    public int turnEnd;

    public void UpdateStatus()
    {
        Image image = gameObject.GetComponent<Image>();
        image.enabled = true;
        image.sprite = skill.skillIMG;
    }

    //public void MouseEnter()
    //{
    //    Transform tip = Instantiate()
    //    //GameManager.hoveringBattleStatusParent = gameObject.transform.parent;
    //    //GameManager.hoveringBattleStatus = true;
    //}

    //public void MouseLeave()
    //{
    //    GameManager.hoveringBattleStatus = false;
    //}

    public string MakeStatusTooltip()
    {
        string tooltip = "";
        switch (skill.skillID)
        {
            case 5:
                {
                    tooltip = string.Format("<size=20>{0}</size>\n<size=15>{1}</size>", skill.skillName, skill.skillEffDesc);
                    return tooltip;
                }
        }
        return tooltip;
    }

}
