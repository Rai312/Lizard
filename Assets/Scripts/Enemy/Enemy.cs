using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction Died;
    public int Health => _health;

    public void TakeDamage(int damage)
    {
        _health -= AffectDamage(damage);

        if (_health < 0)
            _health = 0;

        if (_health == 0)
            Died?.Invoke();
    }

    protected virtual int AffectDamage(int damage)
    {
        return damage;
    }    
}
