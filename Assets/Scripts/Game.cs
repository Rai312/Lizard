using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private FireSkill _fireSkill;
    [SerializeField] private PoisonSkill _poisonSkill;
    [SerializeField] private IceSkill _iceSkill;

    private void OnEnable()
    {
        _fireSkill.ButtonClick += OnFireSkillButtonClick;
        _poisonSkill.ButtonClick += OnPoisonSkillButtonClick;
        _iceSkill.ButtonClick += OnIceSkillButtonClick;
    }

    private void OnFireSkillButtonClick()
    {
        throw new NotImplementedException();
    }

    private void OnPoisonSkillButtonClick()
    {
        throw new NotImplementedException();
    }

    private void OnIceSkillButtonClick()
    {
        throw new NotImplementedException();
    }
}
