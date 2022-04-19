using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : Enemy
{
    [SerializeField] private int _agility;

    protected override int AffectDamage(int damage)
    {
        return damage / _agility;
    }
}
