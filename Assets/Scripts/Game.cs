using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private FireSkill _fireSkill;
    [SerializeField] private PoisonSkill _poisonSkill;
    [SerializeField] private IceSkill _iceSkill;
    [SerializeField] private LookAt _lookAt;
    [SerializeField] private PlayerAnimationController _playerAnimationController;

    //[SerializeField] private Button _fireSkillView;
    //[SerializeField] private Button _poisonSkillView;
    //[SerializeField] private Button _iceSkillView;
    private Enemy _enemy;

    private void OnEnable()
    {
        _fireSkill.ButtonClick += OnFireSkillButtonClick;
        _poisonSkill.ButtonClick += OnPoisonSkillButtonClick;
        _iceSkill.ButtonClick += OnIceSkillButtonClick;
        _lookAt.TargetFound += OnTargetFound;
    }

    private void OnTargetFound(Enemy enemy)
    {
        _enemy = enemy;
    }

    private void OnFireSkillButtonClick()
    {
        _playerAnimationController.Attack();
        _fireSkill.Attack(_enemy);
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
