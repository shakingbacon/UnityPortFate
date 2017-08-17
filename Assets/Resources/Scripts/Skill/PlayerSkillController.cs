using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour {

    public GameObject skillPanel;
    public Transform projectileSpawn;
    public string usingSkillName = "";

    public void ActivateSkill(string skillName)
    {
        CastSkillProjectile(skillName);
    }

    public void CastSkillProjectile(string skillName)
    {
        Projectile projectile = Instantiate(Resources.Load<Projectile>("Prefabs/Skills/" + skillName));
        projectile.Direction = projectileSpawn.right;
        projectile.transform.position = projectileSpawn.position;
        if (projectileSpawn.parent.localScale.x == -1)
        {
            projectile.transform.Rotate(180, 180, 0);
        }
        projectile.transform.localScale = new Vector3(1, 1, 1);
    }
}
