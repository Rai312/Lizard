using UnityEngine;

public class TongueAnimationController : AnimationController//������� �� ��������� �������
{
    public void IceAttack()
    {
        Animator.SetTrigger("IceAttack");//��������
    }

    public void FireAttack()
    {
        Animator.SetTrigger("FireAttack");//��������
    }


    public void PoisonAttack()
    {
        Animator.SetTrigger("PoisonAttack");//��������
    }

    public override void Move()
    {
        Animator.SetBool("IsMoving", true);//��������
        Animator.SetBool("IsAttacking", false);//��������
        Animator.SetBool("Idle", false);//��������
    }

    public override void Idle()
    {
        Animator.SetBool("IsMoving", false);//��������
        Animator.SetBool("IsAttacking", false);//��������
        Animator.SetBool("Idle", true);//��������
    }
}
