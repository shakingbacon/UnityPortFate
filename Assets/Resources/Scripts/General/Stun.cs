using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun {

    public float StunnedDuration { get; set; }
    public bool Stunned { get { return IsStunned(); } }

    bool IsStunned()
    {
        if (StunnedDuration > 0)
        {
            StunnedDuration -= Time.fixedDeltaTime;
            return true;
        }
        return false;
    }

    public void AddStun(float time)
    {
        StunnedDuration += time;
    }

    public Stun()
    {
        StunnedDuration = 0;
    }

    // use this in fixed update
    //if (stun.Stunned)
    //{
    //    return;
    //}

}
