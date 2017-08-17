using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {
    Animator Animator { get; set; }
    List<BaseStat> Stats { get; set; }
    PlayerSkillController playerSkillController { get; set; }
    int CurrentDamage { get; set; }
    void PerformAttack(int damage);
    void PerformSkillAnimation();
    

}
