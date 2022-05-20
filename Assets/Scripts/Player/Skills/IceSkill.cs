public class IceSkill : Skill
{
    protected override void OnClickSkillButton()
    {
        FDebug.Log("IceSkill");
        base.OnClickSkillButton();
        TongueAnimationController.IceAttack();
        TongueMaterialChanger.AssingIceMaterial();
    }
}
