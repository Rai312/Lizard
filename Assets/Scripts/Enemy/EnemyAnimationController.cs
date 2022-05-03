using UnityEngine;

public class EnemyAnimationController : AnimationController
{
    public override void Move()
    {
        Animator.SetBool("IsMove", true);//��������
        Animator.SetBool("IsCheckPositionHipHop", false);//��������
        Animator.SetBool("IsCheckPosition", false);//��������
    }

    public override void Idle()
    {
        Animator.SetBool("IsMove", false);//��������
        Animator.SetBool("IsCheckPositionHipHop", false);//��������
        Animator.SetBool("IsCheckPosition", true);//��������
    }

    public void Attack()/////////////////////////////////////////
    {
        throw new System.NotImplementedException();
    }
}
