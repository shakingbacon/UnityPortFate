using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Glyph : Item {
    [Header("Glyph Info")]
    public List<GlyphColor> glyphColor;
    public int glyphReqLevel;
    public string glyphEqDesc;
    public string glyphNotUseDesc;

    public enum GlyphColor
    {
        Red,
        Blue,
        Green,
        Yellow,
        Rainbow,
    }

    public Glyph(string name, int id, int level, string desc, string eqdesc, string notdesc, int cost, List<GlyphColor> colors)
    {
        itemName = name;
        itemImg = Resources.Load<Sprite>("Item Icons/" + name);
        itemID = id;
        glyphColor = colors;
        glyphReqLevel = level ;
        itemDesc = desc;
        glyphEqDesc = eqdesc;
        glyphNotUseDesc = notdesc;
        itemType = ItemType.Glyph;
        itemCost = cost;
    }

    public Glyph()
    {
        itemID = -1;
    }
}
