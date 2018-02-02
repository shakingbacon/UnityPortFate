using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobSelect : MonoBehaviour
{
    Player player;

    public Button leftButton, middleButton, rightButton;

    public Text leftText, middleText, rightText;

    void Start()
    {
        player = GameManager.Instance.player;
        leftButton.onClick.AddListener(MageSelect);   
    }

    public void MageSelect()
    {
        SoundDatabase.PlaySound(43);
        player.Stats = new Mage();
        PlayerSkillController.Instance.LearnSkill(SkillDatabase.Instance.GetSkill("Fireball"));
        PlayerSkillController.Instance.LearnSkill(SkillDatabase.Instance.GetSkill(1));
        PlayerSkillController.Instance.LearnSkill(2);
        PlayerSkillController.Instance.LearnSkill(3);
        PlayerSkillController.Instance.LearnSkill(4);
        StatusBar.Instance.gameObject.SetActive(true);
        GameManager.Instance.characterPanel.SetActive(true);
        GameManager.Instance.InIntro = false;
        PlayerMovement.cantMove = false;
        player.StartCoroutine(player.Regenerate());
        Destroy(gameObject);
        SoundDatabase.PlayMusic(0);
    }



}
