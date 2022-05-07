using UnityEngine.Events;

public class FireSkill : AttackSkill//тут сделать при нажатие кнопки анимаци и отдельно классы с свойствами скила
{
    //public event UnityAction FireSkillButtonClick;

    protected override void OnClickSkillButton()
    {
        base.OnClickSkillButton();
        //FireSkillButtonClick?.Invoke();
        TongueAnimationController.FireAttack();//дубляж ли с классом?
        //может быть переименовать а то не с галагола начинается,,, attack with fire например
    }
}
