using UnityEngine;

public class Agent : Enemy
{
    [SerializeField] private int _agility;

    protected override int AffectDamage(int damage)
    {
        return Mathf.RoundToInt(damage / _agility);
    }
}
