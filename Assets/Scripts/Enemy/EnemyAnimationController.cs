using UnityEngine;

public class EnemyAnimationController : AnimationController
{
    public override void Move()
    {
        Animator.SetBool("IsMove", true);//À»“≈–¿À€
        Animator.SetBool("IsCheckPositionHipHop", false);//À»“≈–¿À€
        Animator.SetBool("IsCheckPosition", false);//À»“≈–¿À€
    }

    public override void Idle()
    {
        Animator.SetBool("IsMove", false);//À»“≈–¿À€
        Animator.SetBool("IsCheckPositionHipHop", false);//À»“≈–¿À€
        Animator.SetBool("IsCheckPosition", true);//À»“≈–¿À€
    }

    public void Attack()/////////////////////////////////////////
    {
        throw new System.NotImplementedException();
    }
}
