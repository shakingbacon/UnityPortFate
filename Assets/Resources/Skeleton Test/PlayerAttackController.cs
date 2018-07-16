using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public static PlayerAttackController Instance { get; set; }

    Animator animator;



    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Weapon Swing"))
        {
            StartCoroutine(TriggerAnimationCantMove("WeaponSwing"));
        }
    }

    IEnumerator TriggerAnimationCantMove(string name)
    {
        animator.SetTrigger(name);
        yield return null;
        print(animator.GetCurrentAnimatorStateInfo(0).length);
        StartCoroutine(PlayerMovementController.Instance.CannotMove(animator.GetCurrentAnimatorStateInfo(0).length));
    }


}
