public class IceSkill : AttackSkill
{
    protected override void OnClickSkillButton()
    {
        base.OnClickSkillButton();
        TongueAnimationController.IceAttack();
    }
}
