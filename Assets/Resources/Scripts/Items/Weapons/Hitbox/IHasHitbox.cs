using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasHitbox
{
    List<Entity> EntitiesHit { get; set; }
    int Pierce { get; set; }
    int Damage { get; }
    int HitChance { get; }
    float Knockback { get; set; }
    float StunDuration { get; set; }

    void OnHitEffects(Damage dmg);


}
