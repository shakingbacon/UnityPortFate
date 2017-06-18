using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Glyph : Item {
    public GlyphColor glyphColor;
    public int glyphReqLevel;
    public string glyphEqDesc;
    public string glyphNotUseDesc;

    public enum GlyphColor
    {
        Red,
        Blue,
        Green,
        Yellow
    }

    public Glyph(string name, int id, GlyphColor color, int level, string desc, string eqdesc, string notdesc)
    {
        itemName = name;
        itemImg = Resources.Load<Sprite>("Item Icons/" + name);
        itemID = id;
        glyphColor = color;
        glyphReqLevel = level ;
        itemDesc = desc;
        glyphEqDesc = eqdesc;
        glyphNotUseDesc = notdesc;
        itemType = ItemType.Glyph;
    }

    public Glyph()
    {
        itemID = -1;
    }
}
