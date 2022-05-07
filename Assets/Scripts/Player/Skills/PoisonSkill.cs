using UnityEngine.Events;

public class PoisonSkill : AttackSkill
{
    //public event UnityAction PoisonSkillButtonClick;

    protected override void OnClickSkillButton()
    {
        base.OnClickSkillButton();
        //PoisonSkillButtonClick?.Invoke();
        TongueAnimationController.PoisonAttack();//дубляж ли с классом?
    }
}
