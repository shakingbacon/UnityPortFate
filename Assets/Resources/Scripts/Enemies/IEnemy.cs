using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy  {

    MonsterSpawner Spawner { get; set; }
    int MonsterID { get; set; }
    int Experience { get; set; }

    float AttackSpeed { get; set; }


    void Die();
    void DestroySelf();
    void TakeDamage(Damage damage);
    void PerformAttack();
}
