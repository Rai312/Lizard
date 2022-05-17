using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AnimationController : MonoBehaviour
{
    protected Animator Animator;

    protected const string IsMoving = "IsMoving";
    protected const string IsIdle = "IsIdle";
    protected const string IsAttacking = "IsAttacking";

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public abstract void Move();
    public abstract void Idle();
}
