using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlyphHolder : MonoBehaviour {

    public Glyph glyph;

    public void MouseEnter()
    {
        if (glyph.itemID != -1)
        {
            GlyphPage.desc.gameObject.SetActive(true);
            string colors = "";
            for (int i = 0; i < glyph.glyphColor.Count; i++)
            {
                if (i + 1 == glyph.glyphColor.Count)
                {
                    colors += glyph.glyphColor[i].ToString();
                }
                else
                {
                    colors += glyph.glyphColor[i].ToString() + ", ";
                }
            }
            GlyphPage.desc1.text = string.Format("{0} ({1})\nLevel Req: {2}\n{3}", glyph.itemName, colors, glyph.glyphReqLevel, glyph.itemDesc);
            GlyphPage.desc2.text = string.Format("Equipped:\n{0}\nNot used (Battle):\n{1}", glyph.glyphEqDesc, glyph.glyphNotUseDesc);
        }
    }

    public void MouseLeave()
    {
        if (glyph.itemID != -1)
        {
            GlyphPage.desc.gameObject.SetActive(false);
        }
    }


    public void GlyphPageInBattleSelect()
    {
        GlyphPage.glyphPage.gameObject.SetActive(false);
        BattleUI.AddBattleGlyph(glyph);
        SkillPage.skillPage.gameObject.SetActive(false);
    }

    public void GlyphPageEquipClick()
    {
        if (glyph.itemID != -1 && !GameManager.inBattle && gameObject.transform.GetSiblingIndex() != 0)
        {
            if (GlyphPage.AddInvGlyph(glyph.itemID))
            {
                MouseLeave();
                GlyphPage.RemGlyphStats(glyph.itemID);
                gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Item Icons/Glyph Holder");
                GameManager.player.FullUpdate();
                SoundDatabase.PlaySound(0);
                if (InvEq.showStats)
                    InvEq.UpdateStatsDesc();
                glyph = new Glyph();
            }
            else
            {
                SoundDatabase.PlaySound(33);
            }
        }
        else if (GameManager.inBattle && GlyphPage.battleOpen)
        {
            if (glyph.itemID != -1 && !GlyphPage.usedGlyphsBattle.Exists(anInt => anInt == transform.GetSiblingIndex()))
            {
                SoundDatabase.PlaySound(10);
                //Color temp = gameObject.GetComponent<Image>().color;
                //temp.a = 100;
                //gameObject.GetComponent<Image>().color = temp;
                GlyphPage.usedGlyphsBattle.Add(transform.GetSiblingIndex());
                GlyphPageInBattleSelect();
            }
            else
            {
                SoundDatabase.PlaySound(33);
            }
        }
    }

    public void GlyphPageInvClick()
    {
        if (glyph.itemID != -1 && !GameManager.inBattle)
        {
            if (GlyphPage.AddEquipGlyph(glyph.itemID))
            {
                MouseLeave();
                GlyphPage.AddGlyphStats(glyph.itemID);
                GameManager.player.FullUpdate();
                if(InvEq.showStats)
                    InvEq.UpdateStatsDesc();
                glyph = new Glyph();
                SoundDatabase.PlaySound(26);
                gameObject.GetComponent<Image>().enabled = false;
            }
            else
            {
                SoundDatabase.PlaySound(33);
            }
        }
    }
}
