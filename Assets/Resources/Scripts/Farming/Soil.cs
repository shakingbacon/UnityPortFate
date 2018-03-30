using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public Terrain Terrain { get; set; }
    SpriteRenderer sprite;

    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void UpdateSprite()
    {
        sprite = Terrain.Name
    }


}
