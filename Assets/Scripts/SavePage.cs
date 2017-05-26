using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePage : MonoBehaviour {

    public static Transform savePage;
    public static Transform savePageNotifier;

    void Awake()
    {
        savePage = gameObject.transform;
        savePageNotifier = savePage.FindChild("Notifier");
        savePage.FindChild("Close").GetComponent<Button>().onClick.AddListener(() => SoundDatabase.PlaySound(34));
        savePage.FindChild("Close").GetComponent<Button>().onClick.AddListener(() => Destroy(gameObject));
        savePage.FindChild("Close").GetComponent<Button>().onClick.AddListener(SoundDatabase.PlayMusicPrevious);
        savePage.FindChild("Delete All").GetComponent<Button>().onClick.AddListener(ClearAll);
        savePageNotifier = savePage.FindChild("Notifier");
        savePageNotifier.FindChild("No").GetComponent<Button>().onClick.AddListener(() => savePageNotifier.gameObject.SetActive(false));
        savePageNotifier.FindChild("No").GetComponent<Button>().onClick.AddListener(() => SoundDatabase.PlaySound(34));
        //savePageNotifier.FindChild("No").GetComponent<Button>().onClick.AddListener(() => ShowSavePage(false));
    }


    public static void UpdateSavePage(bool saving)
    {
        if (saving)
            savePage.FindChild("Title").GetComponent<Text>().text = "Save\nSave to which Slot?";
        else
            savePage.FindChild("Title").GetComponent<Text>().text = "Load\nLoad which Slot?";
        foreach (Transform saveSlot in savePage.FindChild("Save Slot Grid"))
        {
            saveSlot.GetComponent<Button>().onClick.RemoveAllListeners();
            Text desc = saveSlot.GetComponentInChildren<Text>();
            if (!PlayerPrefs.HasKey("slot_" + saveSlot.GetSiblingIndex() + ".name"))
            {
                if (saving)
                {
                    desc.text = string.Format("Slot {0}\nNew Save", saveSlot.GetSiblingIndex());
                    saveSlot.GetComponent<Button>().onClick.AddListener(() => ShowSavePageNotifier(() => SaveGame(saveSlot.GetSiblingIndex()), true));
                    saveSlot.GetComponent<Button>().onClick.AddListener(() => SavePageNotifierText(
                        string.Format("There is currently no data in this slot.\nSave to Slot {0}?", saveSlot.GetSiblingIndex())));
                }
                else
                {
                    desc.text = string.Format("Slot {0}\nNo Save File\nCannot load", saveSlot.GetSiblingIndex());
                    saveSlot.GetComponent<Button>().onClick.AddListener(() => SoundDatabase.PlaySound(33));
                }
            }
            else
            {
                string slotDesc = "";
                slotDesc += "Name: " + PlayerPrefs.GetString(string.Format("slot_{0}.name", saveSlot.GetSiblingIndex())) +
                    "   Level: " + PlayerPrefs.GetInt(string.Format("slot_{0}.level", saveSlot.GetSiblingIndex()));
                slotDesc += "\nJob: " + JobDatabase.GetJob(PlayerPrefs.GetInt(string.Format("slot_{0}.job", saveSlot.GetSiblingIndex()))).jobName;
                slotDesc += "\nDate: " + PlayerPrefs.GetString(string.Format("slot_{0}.date", saveSlot.GetSiblingIndex()));
                desc.text = "Slot " + saveSlot.GetSiblingIndex() + "\n";
                desc.text += slotDesc;
                if (saving)
                {
                    saveSlot.GetComponent<Button>().onClick.AddListener(() => ShowSavePageNotifier(() => SaveGame(saveSlot.GetSiblingIndex()), true));
                    saveSlot.GetComponent<Button>().onClick.AddListener(() => SavePageNotifierText(
                        string.Format("Are you sure you want to save to Slot {0}?\nYou will be overwriting this save:\n{1}", saveSlot.GetSiblingIndex(), slotDesc)));
                }
                else
                {
                    saveSlot.GetComponent<Button>().onClick.AddListener(() => ShowSavePageNotifier(() => LoadGame(saveSlot.GetSiblingIndex()), true));
                    saveSlot.GetComponent<Button>().onClick.AddListener(() => SavePageNotifierText(
                        string.Format("Are you sure you want to load Slot {0}?\nYou will be loading this save:\n{1}", saveSlot.GetSiblingIndex(), slotDesc)));
                }
            }
        }
    }

    public static void ClearAll()
    {
        PlayerPrefs.DeleteAll();
        UpdateSavePage(true);
    }

    public static void SavePageNotifierText(string text)
    {
        savePageNotifier.GetComponentInChildren<Text>().text = text;
    }

    public static void ShowSavePageNotifier(UnityEngine.Events.UnityAction call, bool yes)
    {
        savePageNotifier.gameObject.SetActive(yes);
        if (yes)
        {
            savePageNotifier.FindChild("Yes").GetComponent<Button>().onClick.RemoveAllListeners();
            savePageNotifier.FindChild("Yes").GetComponent<Button>().onClick.AddListener(call);
            savePageNotifier.FindChild("Yes").GetComponent<Button>().onClick.AddListener(() => Destroy(savePage.gameObject));
            savePageNotifier.FindChild("Yes").GetComponent<Button>().onClick.AddListener(() => savePageNotifier.gameObject.SetActive(false));
            if (GameManager.inIntro)
            {
                savePageNotifier.FindChild("Yes").GetComponent<Button>().onClick.AddListener(Intro.LoadGameAfter);
            }
        }
    }

    public static void SaveGame(int i)
    {
        SoundDatabase.PlaySound(9);
        PlayerData player = GameManager.player;
        PlayerPrefs.SetFloat(string.Format("slot_{0}.pos_x", i), GameObject.FindGameObjectWithTag("Player").transform.localPosition.x);
        PlayerPrefs.SetFloat(string.Format("slot_{0}.pos_y", i), GameObject.FindGameObjectWithTag("Player").transform.localPosition.y);
        PlayerPrefs.SetString(string.Format("slot_{0}.date", i), System.DateTime.Now.ToShortTimeString() + ", " + System.DateTime.Now.ToShortDateString());
        PlayerPrefs.SetString(string.Format("slot_{0}.name", i), player.mingZi);
        PlayerPrefs.SetInt(string.Format("slot_{0}.jobID", i), player.job.jobID);
        PlayerPrefs.SetInt(string.Format("slot_{0}.str.base", i), player.strength.baseAmount);
        //PlayerPrefs.SetInt(string.Format("slot_{0}.str.buff", i), player.strength.buffedAmount);
        PlayerPrefs.SetInt(string.Format("slot_{0}.int.base", i), player.intelligence.baseAmount);
        //PlayerPrefs.SetInt(string.Format("slot_{0}.int.buff", i), player.intelligence.buffedAmount);
        PlayerPrefs.SetInt(string.Format("slot_{0}.agi.base", i), player.agility.baseAmount);
        //PlayerPrefs.SetInt(string.Format("slot_{0}.agi.buff", i), player.agility.buffedAmount);
        PlayerPrefs.SetInt(string.Format("slot_{0}.luk.base", i), player.luck.baseAmount);
        //PlayerPrefs.SetInt(string.Format("slot_{0}.luk.buff", i), player.luck.buffedAmount)
        PlayerPrefs.SetInt(string.Format("slot_{0}.health", i), player.health);
        PlayerPrefs.SetInt(string.Format("slot_{0}.mana", i), player.mana);
        PlayerPrefs.SetInt(string.Format("slot_{0}.level", i), player.level);
        PlayerPrefs.SetInt(string.Format("slot_{0}.sp", i), player.skillPoints);
        PlayerPrefs.SetInt(string.Format("slot_{0}.exp", i), player.experience);
        PlayerPrefs.SetInt(string.Format("slot_{0}.cash", i), player.cash);
        int f = 0;
        foreach (List<Skill> page in player.skills)
            foreach (Skill skill in page)
            {
                if (skill.skillID != -1)
                {
                    PlayerPrefs.SetInt(string.Format("slot_{0}.skill_{1}", i, f), skill.skillID);
                    f += 1;
                }
            }
        f = 0;
        foreach (ItemHolder holder in Inventory.inventoryItems)
        {
            if (holder.item.itemID != 1)
            {
                PlayerPrefs.SetInt(string.Format("slot_{0}.inv_{1}", i, f), holder.item.itemID);
            }
        }
        foreach (Transform eq in Equipment.equipment)
        {
            Item item = eq.GetComponentInChildren<ItemHolder>().item;
            if (item.itemID != 1)
            {
                PlayerPrefs.SetInt(string.Format("slot_{0}.eq_{1}", i, f), item.itemID);
            }
        }
        UpdateSavePage(true);
    }

    public static void LoadGame(int i)
    {
        SoundDatabase.PlaySound(9);
        PlayerData player = GameManager.player;
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerTransform.position = GameObject.Find("Save Position").transform.position;
        Camera.main.transform.position = playerTransform.position;
        player.mingZi = PlayerPrefs.GetString(string.Format("slot_{0}.name", i));
        player.job.jobID = PlayerPrefs.GetInt(string.Format("slot_{0}.jobID", i));
        player.ApplyJob();
        player.strength.baseAmount = PlayerPrefs.GetInt(string.Format("slot_{0}.str.base", i));
        //PlayerPrefs.SetInt(string.Format("slot_{0}.str.buff", i), player.strength.buffedAmount);
        player.intelligence.baseAmount = PlayerPrefs.GetInt(string.Format("slot_{0}.int.base", i));
        //PlayerPrefs.SetInt(string.Format("slot_{0}.int.buff", i), player.intelligence.buffedAmount);
        player.agility.baseAmount = PlayerPrefs.GetInt(string.Format("slot_{0}.agi.base", i));
        //PlayerPrefs.SetInt(string.Format("slot_{0}.agi.buff", i), player.agility.buffedAmount);
        player.luck.baseAmount = PlayerPrefs.GetInt(string.Format("slot_{0}.luk.base", i));
        //PlayerPrefs.SetInt(string.Format("slot_{0}.luk.buff", i), player.luck.buffedAmount)
        player.health = PlayerPrefs.GetInt(string.Format("slot_{0}.health", i));
        player.mana = PlayerPrefs.GetInt(string.Format("slot_{0}.mana", i));
        player.level = PlayerPrefs.GetInt(string.Format("slot_{0}.level", i));
        player.skillPoints = PlayerPrefs.GetInt(string.Format("slot_{0}.sp", i));
        player.experience = PlayerPrefs.GetInt(string.Format("slot_{0}.exp", i));
        player.cash = PlayerPrefs.GetInt(string.Format("slot_{0}.cash", i));
        int f = 0;
        for (; ; f++)
        {
            if (PlayerPrefs.HasKey(string.Format("slot_{0}.inv_{1}", i, f)))
            {
                Inventory.AddItem(PlayerPrefs.GetInt(string.Format("slot_{0}.inv_{1}", i, f)));
            }
            else
                break;
        }
        for (f = 0; ; f++)
        {
            if (PlayerPrefs.HasKey(string.Format("slot_{0}.eq_{1}", i, f)))
            {
                //(string.Format("slot_{0}.eq_{1}", i, f));
            }
            else
                break;
        }

        InvEq.UpdateCashText();
        player.dmgOutput.baseAmount = 100;
        player.dmgTaken.baseAmount = 100;
        player.manaComs.baseAmount = 100;
        player.FullUpdate();
        UpdateSavePage(false);
    }
}
