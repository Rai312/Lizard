using UnityEngine;

public class EnemyAnimationController : AnimationController
{
    private const string IsCheckPosition = "IsCheckPosition";

    public override void Move()
    {
        Animator.SetBool(IsMoving, true);
        Animator.SetBool(IsCheckPosition, false);
    }

    public override void Idle()
    {
        Animator.SetBool(IsMoving, false);
        Animator.SetBool(IsCheckPosition, true);
    }
}
