using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusHolder : MonoBehaviour {

    public Status status;
    public Skill skill;
    public int turnEnd;

    public void UpdateStatus()
    {
        Image image = gameObject.GetComponent<Image>();
        if (status.statusID != -1)
        {
            image.enabled = true;
            image.sprite = Resources.Load<Sprite>("Status Effects/" + status.statusName);
        }
        else if (skill.skillID != -1)
        {
            image.enabled = true;
            image.sprite = skill.skillIMG;
        }
        else
        {
            image.enabled = false;
        }
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
        if (status.statusID != -1)
        {
            switch (status.statusID)
            {
                case 0:
                    {
                        tooltip = string.Format("<color=red>{0}</color>\n<color=black>Deals around 10% of Maximum HP</color>", status.statusName);
                        return tooltip;
                    }
            }
        }
        else if (skill.skillID != -1)
        {
            switch (skill.skillID)
            {
                case 5:
                    {
                        tooltip = string.Format("<size=20>{0}</size>\n<size=15>{1}</size>", skill.skillName, skill.skillEffDesc);
                        return tooltip;
                    }
            }
        }
        return tooltip;
    }

}
