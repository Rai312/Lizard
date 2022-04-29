public class FireSkill : AttackSkill//тут сделать при нажатие кнопки анимаци и отдельно классы с свойствами скила
{
    protected override void OnClickSkillButton()
    {
        TongueAnimationController.FireAttack();//дубляж ли с классом?
        //может быть переименовать а то не с галагола начинается,,, attack with fire например
    }
}
