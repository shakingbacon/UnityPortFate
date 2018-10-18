using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    protected Animator _animator;

    protected bool HoldingArrowKey { get { return _animator.GetBool("HoldingArrowKey"); } set { _animator.SetBool("HoldingArrowKey", value); } }
    protected bool HoldingShift { get { return _animator.GetBool("HoldingShift"); } set { _animator.SetBool("HoldingShift", value); } }
    protected bool CanMove { get { return _animator.GetBool("CanMove"); } set { _animator.SetBool("CanMove", value); } }
    protected bool CanPerformAttack { get { return _animator.GetBool("CanPerformAttack"); } set { _animator.SetBool("CanPerformAttack", value); } }
    protected bool Attacking { get { return _animator.GetBool("Attacking"); } set { _animator.SetBool("Attacking", value); } }
    protected bool WaitingForAttack { get { return _animator.GetBool("WaitingForAttack"); } set { _animator.SetBool("WaitingForAttack", value); } }
    protected float RunningTime { get { return _animator.GetFloat("RunningTime"); } set { _animator.SetFloat("RunningTime", value); } }
    protected float AttackSpeed { get { return _animator.GetFloat("AttackSpeed"); } set { _animator.SetFloat("AttackSpeed", value); } }

    protected void TriggerWeaponSwing() => _animator.SetTrigger("WeaponSwing");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

}
