using UnityEngine.Events;

public class FireSkill : AttackSkill//��� ������� ��� ������� ������ ������� � �������� ������ � ���������� �����
{
    //public event UnityAction FireSkillButtonClick;

    protected override void OnClickSkillButton()
    {
        base.OnClickSkillButton();
        //FireSkillButtonClick?.Invoke();
        TongueAnimationController.FireAttack();//������ �� � �������?
        //����� ���� ������������� � �� �� � �������� ����������,,, attack with fire ��������
    }
}
