using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    //public 
    public int Health => _health;

    public void TakeDamage(int damage)
    {
        _health -= AffectDamage(damage);

        if (_health <= 0)
            _health = 0;

        TryToDie();
    }

    protected virtual int AffectDamage(int damage)
    {
        return damage;
    }    

    private void TryToDie()
    {
        
    }
}
