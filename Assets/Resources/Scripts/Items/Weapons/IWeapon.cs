using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {
    Animator Animator { get; set; }
    List<BaseStat> Stats { get; set; }
    PlayerSkillController playerSkillController { get; set; }
    Damage CurrentDamage { get; set; }
    void PerformAttack(Damage damage);
    void PerformSkillAnimation();
    

}
