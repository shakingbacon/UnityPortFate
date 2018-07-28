using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private Animator _animator;
    public static PlayerAttackController Instance { get; set; }

    private bool CanPerformAttack
    {
        get { return _animator.GetBool("CanPerformAttack"); }
        set { _animator.SetBool("CanPerformAttack", value); }
    }


    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !_animator.GetCurrentAnimatorStateInfo(1).IsTag("AttackFinal") &&
            CanPerformAttack) _animator.SetTrigger("WeaponSwing");
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