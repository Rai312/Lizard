public class FireSkill : Skill
{
    protected override void OnClickSkillButton()
    {
        base.OnClickSkillButton();
        TongueAnimationController.FireAttack();
    }
}
