using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableTransition : Transition
{
    [SerializeField] private AttackHandler _attackHandler;

    private void OnEnable()
    {
        _attackHandler.Attacked += OnAttacked;
    }

    private void OnDisable()
    {
        _attackHandler.Attacked -= OnAttacked;
    }

    private void OnAttacked()//можно в событие передовать какая атака произошла
    {
        NeedTransit = true;
    }
}
