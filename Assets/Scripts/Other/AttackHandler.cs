using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private IceSkill _iceSkill;
    [SerializeField] private FireSkill _fireSkill;
    [SerializeField] private PoisonSkill _poisonSkill;

    public event UnityAction Attacked;

    private void OnEnable()
    {
        _iceSkill.SkillButtonClick += OnIceSkillButtonClick;
        _fireSkill.SkillButtonClick += OnFireSkillButtonClick;
        _poisonSkill.SkillButtonClick += OnPoisonSkillButtonClick;
    }

    private void OnDisable()
    {
        _iceSkill.SkillButtonClick -= OnIceSkillButtonClick;
        _fireSkill.SkillButtonClick -= OnFireSkillButtonClick;
        _poisonSkill.SkillButtonClick -= OnPoisonSkillButtonClick;
    }

    private void OnIceSkillButtonClick()
    {
        _iceSkill.ActiveSkill();
    }

    private void OnFireSkillButtonClick()
    {
        _fireSkill.ActiveSkill();
    }

    private void OnPoisonSkillButtonClick()
    {
        _poisonSkill.ActiveSkill();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Attacked?.Invoke();
            
            Debug.Log($"IceSkill - {_iceSkill.IsClicked}");
            Debug.Log($"FireSkill - {_fireSkill.IsClicked}");
            Debug.Log($"PoisonSkill - {_poisonSkill.IsClicked}");

            if (_iceSkill.IsClicked)
            {
                enemy.TakeDamage(_iceSkill.Damage);
                //ICE - тут делается и со стороны игрока и со стороны врага действие
                enemy.ApplyIceEffect();
            }
            else if (_fireSkill.IsClicked)
            {
                enemy.ApplyFireEffect();
                //FIRE - тут делается и со стороны игрока и со стороны врага действие
            }
            else if (_poisonSkill.IsClicked)
            {
                enemy.ApplyPoisoningEffect();
                //POISON - тут делается и со стороны игрока и со стороны врага действие
            }
        }
    }
}
