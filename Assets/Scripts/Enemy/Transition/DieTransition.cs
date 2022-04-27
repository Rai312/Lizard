using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DieTransition : Transition
{
    //[SerializeField] private Enemy[] _enemies; 
    //[SerializeField] private Enemy _enemy;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        //foreach (var enemy in _enemies)
        //{
        Debug.Log(_enemy.Health);
        if (_enemy.Health <= 0)
        {
            Debug.Log("NeedTransit = true;");//можно сделать событие о смерти в самом enemy
            NeedTransit = true;//не должен вызываться постоянно
        }
        //}

    }
}
