using System;
using UnityEngine;

public class Agent : Enemy
{
    [SerializeField] private int _agility;

    protected override int AffectDamage(int damage)
    {
        //Debug.Log(Mathf.RoundToInt(damage / _agility));
        return Mathf.RoundToInt(damage / _agility);
    }
}
