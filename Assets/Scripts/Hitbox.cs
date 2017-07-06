using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.position = new Vector3(other.transform.position.x + 1, other.transform.position.y, other.transform.position.z);
        }
    }

    public static IEnumerator SummonHitbox(Skill skill)
    {
        if (!GameManager.inSkillAnimation)
        {
            SoundDatabase.PlaySound(0);
            GameObject hitbox = Instantiate(Resources.LoadAll<GameObject>("Hitboxes")[skill.skillHitboxData.hitboxID], GameManager.playerGameObject.transform.FindChild("Hitbox Pos1"));
            hitbox.transform.localPosition = new Vector3(0, 0);
            hitbox.transform.localScale = new Vector3(1, 1, 1);
            GameManager.cantMove = true;
            GameManager.inSkillAnimation = true;
            yield return new WaitForSeconds(skill.skillHitboxData.hitboxTimer);
            Destroy(hitbox);
            GameManager.inSkillAnimation = false;
            GameManager.cantMove = false;
        }
    }
}
