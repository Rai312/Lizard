using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoisonSkill : AttackSkill
{
    protected override void OnClickSkillButton()
    {
        TongueAnimationController.PoisonAttack();//дубляж ли с классом?
        
    }
}
