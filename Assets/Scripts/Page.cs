using UnityEngine;
using System.Collections;


[System.Serializable]
public class Page
{
    public int id;
    public float x, y, w, h, titleh;
    public bool showPage;

    public GUISkin skin;

    public Page(int pageid, float pagex, float pagey, float pagew, float pageh, float pagetitleh)
    {
        id = pageid;
        x = pagex;
        y = pagey;
        w = pagew;
        h = pageh;
        titleh = pagetitleh;
    }
}

   
        
    

