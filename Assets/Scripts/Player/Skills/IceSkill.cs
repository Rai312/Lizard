using UnityEngine.Events;

public class IceSkill : AttackSkill
{
    //public event UnityAction IceSkillButtonClick;

    protected override void OnClickSkillButton()
    {
        base.OnClickSkillButton();
        //IceSkillButtonClick?.Invoke();
        TongueAnimationController.IceAttack();//������ �� � �������?
    }

    //������� ������ ���������� bool, ����� ���� ���� ������� ��������� ������ ������
}
