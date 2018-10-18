using UnityEngine;

public class PlayerAttackController : PlayerAnimatorController
{
    public static PlayerAttackController Instance { get; set; }

    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    private void Update()
    {
        Attacking = _animator.GetCurrentAnimatorStateInfo(1).IsTag("Attack");
        if (Input.GetKeyDown(KeyCode.X) && CanPerformAttack)
        {
            if (!WaitingForAttack) WaitingForAttack = true;
            _animator.SetTrigger("WeaponSwing");
        }
    }

    private void BasicPerformAttackStartEvents()
    {
        CanPerformAttack = false;
        WaitingForAttack = false;
        CanMove = false;
    }

    private void DisablePerformAttack() => CanPerformAttack = false;
    private void EnablePerformAttack() => CanPerformAttack = true;

    //private IEnumerator TriggerAnimationCantMove(string name)
    //{
    //    animator.SetTrigger(name);
    //    yield return new WaitForEndOfFrame();
    //    print(animator.GetCurrentAnimatorStateInfo(1).length);
    //    StartCoroutine(PlayerMovementController.Instance.CannotMove(animator.GetCurrentAnimatorStateInfo(0).length));
    //}
}