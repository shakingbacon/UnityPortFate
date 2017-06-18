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
            GlyphPage.desc1.text = string.Format("{0} ({1})\nLevel Req: {2}\n{3}", glyph.itemName, glyph.glyphColor, glyph.glyphReqLevel, glyph.itemDesc);
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

    public void GlyphPageEquipClick()
    {
        if (glyph.itemID != -1 && !GameManager.inBattle)
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
