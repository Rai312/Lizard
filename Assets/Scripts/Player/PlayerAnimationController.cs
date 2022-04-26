using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Attack()
    {
        _animator.SetBool("IsMoving", false);
        _animator.SetBool("IsAttacking", true);
        _animator.SetBool("Idle", false);
    }

    public void Move()
    {
        _animator.SetBool("IsMoving", true);
        _animator.SetBool("IsAttacking", false);
        _animator.SetBool("Idle", false);
    }

    public void Idle()
    {
        _animator.SetBool("IsMoving", false);
        _animator.SetBool("IsAttacking", false);
        _animator.SetBool("Idle", true);
    }
}
