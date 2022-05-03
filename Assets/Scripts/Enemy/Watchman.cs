using UnityEngine;

public class Watchman : Enemy
{
    [SerializeField] private int _armor;

    protected override int AffectDamage(int damage)
    {
        return damage - _armor;
    }
}
