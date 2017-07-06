using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillHitboxData {
    public int hitboxID;
    public float hitboxTimer;

    public SkillHitboxData()
    {
        hitboxID = -1;
    }

    public SkillHitboxData(int id, float time)
    {
        hitboxID = id;
        hitboxTimer = time;
        
    }
}
