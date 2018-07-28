using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public enum EntityType
    {
        Human,
        Reptile
    }

    public string Name { get; set; }
    public Attributes Stats { get; set; } = new Attributes();

    public bool CanRegenerate { get; set; }
    public bool CanBeHit { get; set; }


    public EntityType Type { get; set; }

    public abstract void TakeDamage(Damage damage);
    public abstract void Die();
}