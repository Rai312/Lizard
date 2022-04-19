using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoisonSkill : AttackSkill
{
    public event UnityAction ButtonClick;

    protected override void OnSkillButton()
    {
        ButtonClick?.Invoke();
    }
}
