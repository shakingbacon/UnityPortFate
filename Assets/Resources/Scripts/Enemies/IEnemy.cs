using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy  {


    Animator Animator { get; set; }
    MonsterSpawner Spawner { get; set; }
    EnemyFollow EnemyFollow { get; set; }

    int CurrentHealth { get; set; }
    int CurrentMana { get; set; }
    //int Cash { get; set; }
    int Experience { get; set; }
    float AttackCooldown { get; set; }
    CharacterStats Stats { get; set; }
    DropTable DropTable { get; set; }

    Player Player { get; set; }
    PickupItem PickupItemPrefab { get; set; }
    EnemyHealthBar HealthBar { get; set; }

    void DealDamage();
    void PerformAttack();

    void Attacking();
    void FinishAttacking();

    void TakeDamage(Damage damage);
    void HealthDamaged(int amount);

    void AfterSpawning();
    void DestroyHealthBar();
    void Die();
    void DestroySelf();
    void DropLoot();
    

}
