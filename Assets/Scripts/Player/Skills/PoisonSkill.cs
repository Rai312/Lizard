public class PoisonSkill : AttackSkill
{
    protected override void OnClickSkillButton()
    {
        base.OnClickSkillButton();
        TongueAnimationController.PoisonAttack();
    }
}
