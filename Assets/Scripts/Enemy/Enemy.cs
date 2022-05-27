using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private BoxCollider _boxCollider;

    public event UnityAction<Enemy> Died;
    public int Health => _health;
    public bool IsDead { get; private set; } = false;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    public void TakeDamage(int damage)
    {
        _health -= AffectDamage(damage);

        if (_health < 0)
            _health = 0;

        if (_health == 0)
        {
            Died?.Invoke(this);
            IsDead = true;
        }
    }

    public void DisableCollider()
    {
        _boxCollider.enabled = false;
    }

    protected virtual int AffectDamage(int damage)
    {
        return damage;
    }
}
