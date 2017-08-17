using System.Collections.Generic;

public interface IWeapon {

    List<BaseStat> Stats { get; set; }
    PlayerSkillController playerSkillController { get; set; }
    int CurrentDamage { get; set; }
    void PerformAttack(int damage);
    void PerformSkillAnimation();
    

}
