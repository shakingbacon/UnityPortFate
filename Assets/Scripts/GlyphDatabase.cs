using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlyphDatabase : MonoBehaviour {

    public static  List<Glyph> glyphs = new List<Glyph>();

	void Start ()
    {
        glyphs.Add(new Glyph("Ember Glyph", 0, 1, "A red glyph", "Int: +2", "PATK/MATK: +35", 250, new List<Glyph.GlyphColor>(new Glyph.GlyphColor[] { Glyph.GlyphColor.Red})));
        glyphs.Add(new Glyph("Droplet Glyph", 1, 1, "A blue glyph", "MP: +100", "Dodge: +4%", 250, new List<Glyph.GlyphColor>(new Glyph.GlyphColor[] { Glyph.GlyphColor.Blue })));
        glyphs.Add(new Glyph("Breeze Glyph", 2, 1, "A green glyph", "Crit Multi: +2%", "Hit: +4%", 250, new List<Glyph.GlyphColor>(new Glyph.GlyphColor[] { Glyph.GlyphColor.Green })));
        glyphs.Add(new Glyph("Static Glyph", 3, 1, "A yellow glyph", "Crit: +2%", "Dodge: +3%", 250, new List<Glyph.GlyphColor>(new Glyph.GlyphColor[] { Glyph.GlyphColor.Yellow })));
        glyphs.Add(new Glyph("Shining Glyph", 4, 1, "A bright glyph", "Hit: +1%\nInt: +1", "PATK/MATK: +15\nDEF/RES: +15", 250, new List<Glyph.GlyphColor>(new Glyph.GlyphColor[] { Glyph.GlyphColor.Red, Glyph.GlyphColor.Yellow })));
        glyphs.Add(new Glyph("Night Glyph", 5,  1, "A dark glyph", "Dodge: +2%", "Crit: +4%", 250, new List<Glyph.GlyphColor>(new Glyph.GlyphColor[] { Glyph.GlyphColor.Blue })));
        glyphs.Add(new Glyph("Ghost Glyph", 6, 1, "A scary glyph", "MP: +75\nHit: +2%", "Crit: +4%", 250, new List<Glyph.GlyphColor>(new Glyph.GlyphColor[] { Glyph.GlyphColor.Green, Glyph.GlyphColor.Blue })));
        glyphs.Add(new Glyph("Leaf Glyph", 7, 1, "A natural glyph", "HP: +75", "DEF/RES: +40", 250, new List<Glyph.GlyphColor>(new Glyph.GlyphColor[] { Glyph.GlyphColor.Green })));
        glyphs.Add(new Glyph("Self Glyph", 8, 0, "Your own glyph", "", "", 0, new List<Glyph.GlyphColor>(new Glyph.GlyphColor[] { Glyph.GlyphColor.Rainbow })));



        foreach (Glyph glyph in glyphs)
        {
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
            glyph.itemStatText += string.Format("<color=black>\nColor(s): {0}\nLevel Req: {1}\n\n", colors, glyph.glyphReqLevel);
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
