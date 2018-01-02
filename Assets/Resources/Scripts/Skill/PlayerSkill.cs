using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : Skill
{
    public float cooldownRemain;

    public PlayerSkill(Skill skill) : base(skill)
    {
        cooldownRemain = 0;
    }
}
