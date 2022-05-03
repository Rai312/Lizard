using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DieTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
    }

    private void OnDied()
    {
        Debug.Log("NeedTransit = true;");
        NeedTransit = true;
    }
}
