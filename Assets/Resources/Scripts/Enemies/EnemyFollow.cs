using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public Transform target;
    public int moveSpeed = 3;
    public int rotationSpeed = 3;
    public float range;
    public float range1;
    public float stop;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //target the player
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        print(distance);

        if (distance <= range && distance > stop)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (distance <= stop)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
        }


    }

}
