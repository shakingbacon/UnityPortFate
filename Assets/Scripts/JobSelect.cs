using UnityEngine;
using System.Collections;

public class JobSelect : MonoBehaviour {

    public static void AddBaseStats()
    {
        GameManager.player.level = 1;
        GameManager.player.strength.baseAmount = 3;
        GameManager.player.intelligence.baseAmount = 3;
        GameManager.player.agility.baseAmount = 3;
        GameManager.player.luck.baseAmount = 3;
        GameManager.player.critMulti.baseAmount = 225;
        GameManager.player.dmgOutput.baseAmount = 100;
        GameManager.player.dmgTaken.baseAmount = 100;
        GameManager.player.manaComs.baseAmount = 100;
        GameManager.player.cash = 100;
        GameManager.player.FullUpdate();
        GameManager.player.HealFullHP();
        GameManager.player.HealFullMP();
        GameManager.player.SetMaxExp();
        //InvEq.UpdateCashText();
        StatusBar.UpdateStatusBar();
    }

    public void SelectMage()
    {
        SoundDatabase.PlaySound(43);
        GameManager.player.job = JobDatabase.GetJob(0);
        AddBaseStats();
        GameManager.player.ApplyJob();
        SkillPage.currentPage = GameManager.player.skillsJob.skills;
        SkillPage.UpdateSkillPage(0);
        SkillPage.UpdateSkillPoints();
        GameManager.inIntro = false;
        Tutorial.skip.gameObject.transform.parent.gameObject.SetActive(true);
        StatusBar.statusBar.gameObject.SetActive(true);
        SoundDatabase.PlayMusic(0);
        Destroy(gameObject);
    }
    public void SelectRogue()
    {
        GameManager.player.job = JobDatabase.GetJob(1);
    }
    public void SelectWarrior()
    {
        GameManager.player.job = JobDatabase.GetJob(2);
    }
}
