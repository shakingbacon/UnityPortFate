using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentHazard : MonoBehaviour {
    public int damage;

    void OnTriggerEnter2D(Collider2D player)
    {
        SoundDatabase.PlaySound(26);
        GameManager.player.HealHP(-(damage));
        StatusBar.UpdateSliders();
        GameManager.IsPlayerDead();
    }
}
