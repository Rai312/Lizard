public class FireSkill : AttackSkill
{
    protected override void OnClickSkillButton()
    {
        base.OnClickSkillButton();
        TongueAnimationController.FireAttack();
    }
}
