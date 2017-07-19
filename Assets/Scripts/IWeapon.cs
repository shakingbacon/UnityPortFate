using System.Collections.Generic;

public interface IWeapon {
    List<BaseStat> Stats { get; set; }
    CharacterStats CharacterStats { get; set; }
    void PerformAttack();
    void PerformSpecialAttack();

}
