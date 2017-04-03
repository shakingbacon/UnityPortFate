using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : MonoBehaviour
{
    public static Transform enemyHolder;
    public static Enemy enemy;
    void Start()
    {
        enemyHolder = gameObject.transform;
    }
}
