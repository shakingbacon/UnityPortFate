using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }
    Vector3 spawnPosition;

    void Start()
    {
        Range = 3f;
        Damage = 15;
        spawnPosition = transform.position;
        GetComponent<Rigidbody2D>().AddForce(Direction * 150f * GameManager.player.transform.localScale.x);
    }

    void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            Extinguish();
        }
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            SoundDatabase.PlaySound(13);
            col.gameObject.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        Extinguish();
    }

}
