using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour {
    Player player;
    public int Level { get; set; }
    public int CurrentExperience { get; set;}
    public int RequiredExperience { get { return Level * 25; } }

    void Start()
    {
        player = GetComponent<Player>();
        CombatEvents.OnEnemyDeath += EnemyToExperience;
        Level = 1;
    }

    void EnemyToExperience(Enemy enemy)
    {
        GrantExperience(enemy.Experience);
    }

    void GrantExperience(int amount)
    {
        CurrentExperience += amount;
        while (CurrentExperience >= RequiredExperience)
        {
            CurrentExperience -= RequiredExperience;
            LevelUp();
        }
        UIEventHandler.ExpChanged();
    }
    
    public void LevelUp()
    {
        SoundDatabase.PlaySound(47);
        EventNotifier.Instance.MakeEventNotifier(string.Format("Leveled Up! {0} -> {1}", Level, Level + 1));
        Level += 1;
        if (Level % 5 == 0) player.SkillPoints += 2;
        else player.SkillPoints += 1;
        player.StatsUpdate();
        player.HealFullHP();
        player.HealFullMP();
    }
}
