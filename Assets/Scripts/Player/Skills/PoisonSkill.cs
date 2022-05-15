public class PoisonSkill : Skill
{
    protected override void OnClickSkillButton()
    {
        base.OnClickSkillButton();
        TongueAnimationController.PoisonAttack();
    }
}
