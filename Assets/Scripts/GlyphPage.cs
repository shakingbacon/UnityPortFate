using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlyphPage : MonoBehaviour {
    public static Transform glyphPage;
    public static Transform glyphEquip;
    public static Transform glyphInv;
    public static Transform desc;
    public static Button close;
    public static Text desc1;
    public static Text desc2;
    public static bool battleOpen = false;
    public static List<int> usedGlyphsBattle = new List<int>();
    public static Skill selectedSkill;

    void Start()
    {
        glyphPage = gameObject.transform;
        glyphEquip = glyphPage.FindChild("Glyph Equip");
        glyphInv = glyphPage.FindChild("Glyph Inventory");
        desc = glyphPage.FindChild("Desc");
        desc1 = glyphPage.FindChild("Desc").GetChild(0).GetComponent<Text>();
        desc2 = glyphPage.FindChild("Desc").GetChild(1).GetComponent<Text>();
        close = glyphPage.FindChild("Close").GetComponent<Button>();
        close.onClick.AddListener(() => glyphPage.gameObject.SetActive(false));
        close.onClick.AddListener(() => SoundDatabase.PlaySound(34));
        EquipGlyph(8); // this is the base glyph
    }

    public static void EquipGlyph(int id)
    {
        AddEquipGlyph(id);
        AddGlyphStats(id);
    }

    public static bool AddEquipGlyph(int id)
    {
        foreach (Transform holders in glyphEquip)
        {
            GlyphHolder holder = holders.GetComponent<GlyphHolder>();
            Glyph addingGlyph = GlyphDatabase.GetGlyph(id);
            if (holder.glyph.itemID == -1)
            {
                holder.glyph = addingGlyph;
                holders.GetComponent<Image>().sprite = holder.glyph.itemImg;
                return true;
            }
        }
        return false;
    }

    public static void OpenBattleGlyphPage()
    {
        glyphInv.gameObject.SetActive(false);
        glyphPage.gameObject.SetActive(true);
        battleOpen = true;
    }

    public static bool AddInvGlyph(int id)
    {
        foreach (Transform holders in glyphInv)
        {
            GlyphHolder holder = holders.GetComponentInChildren<GlyphHolder>();
            Glyph addingGlyph = GlyphDatabase.GetGlyph(id);
            if (holder.glyph.itemID == -1)
            {
                holder.glyph = addingGlyph;
                holders.GetChild(0).GetComponent<Image>().sprite = holder.glyph.itemImg;
                holders.GetChild(0).GetComponent<Image>().enabled = true;
                return true;
            }
        }
        return false;
    }

    public static void AddGlyphStats(int id)
    {
        PlayerData player = GameManager.player;
        switch (id)
        {
            case 0: { player.intelligence.buffedAmount += 2; break; }
        }
    }

    public static void RemGlyphStats(int id)
    {
        PlayerData player = GameManager.player;
        switch (id)
        {
            case 0: { player.intelligence.buffedAmount -= 2; break; }
        }
    }

}
