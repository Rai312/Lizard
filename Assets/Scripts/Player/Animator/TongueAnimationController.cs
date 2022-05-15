using UnityEngine;

public class TongueAnimationController : AnimationController
{
    private const string _iceAttack = "IceAttack";
    private const string _fireAttack = "FireAttack";
    private const string _poisonAttack = "PoisonAttack";

    public override void Move()
    {
        Animator.SetBool(IsMoving, true);
        Animator.SetBool(IsAttacking, false);
        Animator.SetBool(IsIdle, false);
    }

    public override void Idle()
    {
        Animator.SetBool(IsMoving, false);
        Animator.SetBool(IsAttacking, false);
        Animator.SetBool(IsIdle, true);
    }

    public void IceAttack()
    {
        Animator.SetTrigger(_iceAttack);
    }

    public void FireAttack()
    {
        Animator.SetTrigger(_fireAttack);
    }

    public void PoisonAttack()
    {
        Animator.SetTrigger(_poisonAttack);
    }
}
