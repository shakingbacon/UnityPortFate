using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    GameObject playerGameObject;
    public static bool inSkillAnimation;

    void Start()
    {
        playerGameObject = GameManager.playerGameObject;
    }

    void Update()
    {
        if (Input.GetButtonDown("BasicAttack"))
        {
            playerGameObject.transform.FindChild("Hand").GetComponentInChildren<PlayerWeapon>().PlayerWeaponAttack();
        }
    }

}
