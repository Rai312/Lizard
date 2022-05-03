using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

public class LookAt : MonoBehaviour
{//ѕодумать над названием класса
    [SerializeField] private MultiAimConstraint _multiAimConstraint;
    [SerializeField] private RigBuilder _rigBuilder;

    //private bool _isEnemyDead;

    public event UnityAction TargetFound;
    public event UnityAction TargetLost;
    //public event UnityAction TargetDied;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (enemy.IsDead == false)
            {
                enemy.Died += OnDied;//ќ“ѕ»—ј“№—я!!!

                WeightedTransform target;
                target.transform = enemy.transform;
                target.weight = 1f;//MAGIC INT



                var sourceObjects = _multiAimConstraint.data.sourceObjects;//дубл€ж var
                sourceObjects.Clear();

                sourceObjects.Insert(0, target);

                _multiAimConstraint.data.sourceObjects = sourceObjects;
                Debug.Log("OnTriggerEnter");
                _rigBuilder.Build();

                TargetFound?.Invoke();
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.TryGetComponent<Enemy>(out Enemy enemy))
    //    {
    //        if (_isEnemyDead)
    //        {

    //        }
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Died -= OnDied;

            var sourceObjects = _multiAimConstraint.data.sourceObjects; //дубл€ж var
            sourceObjects.Clear();

            _multiAimConstraint.data.sourceObjects = sourceObjects;

            _rigBuilder.Build();
            Debug.Log("OnTriggerExit");//MAGIC INT
            TargetLost?.Invoke();
        }
    }

    private void OnDied()
    {
        var sourceObjects = _multiAimConstraint.data.sourceObjects;
        sourceObjects.Clear();
        _multiAimConstraint.data.sourceObjects = sourceObjects;
        _rigBuilder.Build();
    }
}
