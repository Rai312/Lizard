using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

public class LookAt : MonoBehaviour
{//ѕодумать над названием класса
    [SerializeField] private MultiAimConstraint _multiAimConstraint;
    [SerializeField] private RigBuilder _rigBuilder;

    public event UnityAction TargetFound;
    public event UnityAction TargetLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {

            WeightedTransform target;
            target.transform = enemy.transform;
            target.weight = 1f;//MAGIC INT

            var sourceObjects = _multiAimConstraint.data.sourceObjects;//дубл€ж var

            sourceObjects.Insert(0, target);

            _multiAimConstraint.data.sourceObjects = sourceObjects;
            Debug.Log("OnTriggerEnter");
            _rigBuilder.Build();

            TargetFound?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            var sourceObjects = _multiAimConstraint.data.sourceObjects; //дубл€ж var
            sourceObjects.Clear();

            _multiAimConstraint.data.sourceObjects = sourceObjects;

            _rigBuilder.Build();
            Debug.Log("OnTriggerExit");//MAGIC INT
            TargetLost?.Invoke();
        }
    }
}
