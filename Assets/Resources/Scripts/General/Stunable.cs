using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunable
{
    // you must reduce StunnedDuration -= time .fixeddeltatime in fxied update if usiong
    public float StunnedDuration { get; set; }
    public bool Stunned { get { return IsStunned(); } }

    bool IsStunned()
    {
        if (StunnedDuration > 0) return true;
        return false;
    }

    public void AddStun(float time)
    {
        StunnedDuration += time;
    }

    public Stunable()
    {
        StunnedDuration = 0;
    }
}

