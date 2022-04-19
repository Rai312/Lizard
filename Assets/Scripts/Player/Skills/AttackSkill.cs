using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AttackSkill : MonoBehaviour
{
    [SerializeField] protected Button SkillButton;

    protected virtual void OnEnable()
    {
        SkillButton.onClick.AddListener(OnSkillButton);
    }

    protected virtual void OnDisable()
    {
        SkillButton.onClick.RemoveListener(OnSkillButton);
    }

    protected abstract void OnSkillButton();
}
