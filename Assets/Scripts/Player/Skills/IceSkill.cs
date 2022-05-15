public class IceSkill : Skill
{
    protected override void OnClickSkillButton()
    {
        base.OnClickSkillButton();
        TongueAnimationController.IceAttack();
    }
}
