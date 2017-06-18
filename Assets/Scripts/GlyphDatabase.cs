using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlyphDatabase : MonoBehaviour {

    public static  List<Glyph> glyphs = new List<Glyph>();

	void Start ()
    {
        glyphs.Add(new Glyph("Fire Glyph", 0, Glyph.GlyphColor.Red, 1, "A red glyph", "Int: +3", "PATK / MATK: +35"));
        glyphs.Add(new Glyph("Water Glyph", 1, Glyph.GlyphColor.Blue, 1, "A blue glyph", "Mana: +100", "Crit: +4%"));
        glyphs.Add(new Glyph("Wind Glyph", 2, Glyph.GlyphColor.Green, 1, "A green glyph", "Dodge: +3%", "Hit: +7%"));
        glyphs.Add(new Glyph("Lightning Glyph", 3, Glyph.GlyphColor.Yellow, 1, "A yellow glyph", "Hit: +3%", "Dodge: +4%"));
        foreach(Glyph glyph in glyphs)
        {
            glyph.itemStatText += string.Format("<color=black>\nColor: {0}\nLevel Req: {1}\n\n", glyph.glyphColor, glyph.glyphReqLevel);
            glyph.itemStatText += string.Format("Equipped:\n{0}\n\nNot used (Battle):\n{1}</color>", glyph.glyphEqDesc, glyph.glyphNotUseDesc);
        }
    }




    public static Glyph GetGlyph(int id)
    {
        foreach (Glyph glyph in glyphs)
        {
            if (glyph.itemID == id)
            {
                return glyph;
            }
        }
        return new Glyph();
    }
}
