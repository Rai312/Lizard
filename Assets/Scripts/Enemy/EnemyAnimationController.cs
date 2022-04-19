using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void CheckPosition()
    {
        _animator.SetBool("IsMove", false);
        _animator.SetBool("IsCheckPositionHipHop", false);
        _animator.SetBool("IsCheckPosition", true);
    }

    public void Move()
    {
        _animator.SetBool("IsMove", true);
        _animator.SetBool("IsCheckPositionHipHop", false);
        _animator.SetBool("IsCheckPosition", false);
    }

    public void CheckPositionHipHop()
    {
        _animator.SetBool("IsMove", false);
        _animator.SetBool("IsCheckPosition", false);
        _animator.SetBool("IsCheckPositionHipHop", true);
    }
}
