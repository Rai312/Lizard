using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AnimationController : MonoBehaviour
{
    protected Animator Animator;

    protected readonly string IsMoving = "IsMoving";
    protected readonly string IsIdle = "IsIdle";
    protected readonly string IsAttacking = "IsAttacking";

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public abstract void Move();
    public abstract void Idle();
    //public abstract void Attack();
}
