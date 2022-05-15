public class LizardAnimationController : AnimationController
{
    public void Attack()
    {
        Animator.SetBool(IsMoving, false);
        Animator.SetBool(IsIdle, false);
        Animator.SetBool(IsAttacking, true);
    }

    public override void Idle()
    {
        FDebug.Log("LizardAnimationController - Idle");
        Animator.SetBool(IsMoving, false);
        Animator.SetBool(IsIdle, true);
        Animator.SetBool(IsAttacking, false);
    }

    public override void Move()
    {
        Animator.SetBool(IsMoving, true);
        Animator.SetBool(IsIdle, false);
        Animator.SetBool(IsAttacking, false);
    }
}
