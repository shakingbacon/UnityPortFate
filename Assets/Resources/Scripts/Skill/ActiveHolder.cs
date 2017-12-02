using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveHolder : MonoBehaviour {
    public Image activeImage, cooldown;
    public Skill activeSkill;
    public float timeLeft;
    public float timeMax;

    void FixedUpdate()
    {
        timeLeft -= Time.fixedDeltaTime;
        cooldown.fillAmount = timeLeft / timeMax;
        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetTimeLeft(float duration)
    {
        timeMax = duration;
        timeLeft = duration;
    }
}
