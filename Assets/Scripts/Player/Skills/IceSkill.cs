using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IceSkill : AttackSkill
{
    protected override void OnClickSkillButton()
    {
        TongueAnimationController.IceAttack();//дубляж ли с классом?
    }
}
