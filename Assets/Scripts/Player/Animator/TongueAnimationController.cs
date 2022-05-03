using UnityEngine;

public class TongueAnimationController : AnimationController//ğàçáèòü íà íåñêîëüêî êëàññîâ
{
    public void IceAttack()
    {
        Animator.SetTrigger("IceAttack");//ËÈÒÅĞÀËÛ
    }

    public void FireAttack()
    {
        Animator.SetTrigger("FireAttack");//ËÈÒÅĞÀËÛ
    }


    public void PoisonAttack()
    {
        Animator.SetTrigger("PoisonAttack");//ËÈÒÅĞÀËÛ
    }

    public override void Move()
    {
        Animator.SetBool("IsMoving", true);//ËÈÒÅĞÀËÛ
        Animator.SetBool("IsAttacking", false);//ËÈÒÅĞÀËÛ
        Animator.SetBool("Idle", false);//ËÈÒÅĞÀËÛ
    }

    public override void Idle()
    {
        Animator.SetBool("IsMoving", false);//ËÈÒÅĞÀËÛ
        Animator.SetBool("IsAttacking", false);//ËÈÒÅĞÀËÛ
        Animator.SetBool("Idle", true);//ËÈÒÅĞÀËÛ
    }
}
