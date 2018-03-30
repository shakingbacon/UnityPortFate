using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public string Name { get; set; }
    public Attributes Stats { get; set; } = new Attributes();


    public EntityType Type { get; set; }
    public enum EntityType
    {
        Human,
        Reptile
    }

    public abstract void TakeDamage(Damage damage);
    public abstract void Die();
}
