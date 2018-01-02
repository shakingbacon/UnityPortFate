using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelSkill : MonoBehaviour
{

    public PlayerSkill playerSkill;
    public Image skillImage;
    public Image cooldownCircle;
    public Text key;

    static Sprite skillNullSprite = null;


    void Start()
    {
        if (skillNullSprite == null)
            skillNullSprite = Resources.Load<Sprite>("Icons/UI/CrossBlue");
        playerSkill = null;
        skillImage.sprite = skillNullSprite;
        key.text = gameObject.name;
    }

    void Update()
    {
        if (playerSkill != null)
        {
            if (playerSkill.cooldownRemain > 0)
            {
                cooldownCircle.fillAmount = playerSkill.cooldownRemain / playerSkill.skillCooldown;

            }
            else
            {
                cooldownCircle.fillAmount = 0;
            }
        }
    }

    public void UpdateImage()
    {
        if (playerSkill == null)
        {
            skillImage.sprite = skillNullSprite;
        }
        else
        {
            skillImage.sprite = Resources.Load<Sprite>("Icons/Skills/" + playerSkill.skillName);
        }
    }

    public void SkillUsed()
    {
        playerSkill.cooldownRemain = playerSkill.skillCooldown;
    }

}
