using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

public class LookAt : MonoBehaviour
{
    [SerializeField] private MultiAimConstraint _multiAimConstraint;
    [SerializeField] private RigBuilder _rigBuilder;

    private float _targetWeight = 1f;

    public event UnityAction TargetFound;
    public event UnityAction TargetLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (enemy.IsDead == false)
            {
                enemy.Died += OnDied;

                WeightedTransform target;
                target.transform = enemy.transform;
                target.weight = _targetWeight;

                var sourceObjects = GetSourceObjects();
                sourceObjects.Insert(0, target);

                _multiAimConstraint.data.sourceObjects = sourceObjects;
                _rigBuilder.Build();

                TargetFound?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Died -= OnDied;

            _multiAimConstraint.data.sourceObjects = GetSourceObjects();
            _rigBuilder.Build();

            TargetLost?.Invoke();
        }
    }

    private WeightedTransformArray GetSourceObjects()
    {
        var sourceObjects = _multiAimConstraint.data.sourceObjects;
        sourceObjects.Clear();

        return sourceObjects;
    }

    private void OnDied()
    {
        var sourceObjects = GetSourceObjects();
        _multiAimConstraint.data.sourceObjects = sourceObjects;
        _rigBuilder.Build();
    }
}
