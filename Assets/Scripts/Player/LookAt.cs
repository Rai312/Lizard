using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

public class LookAt : MonoBehaviour
{//�������� ��� ��������� ������
    [SerializeField] private MultiAimConstraint _multiAimConstraint;
    [SerializeField] private RigBuilder _rigBuilder;

    public event UnityAction<Enemy> TargetFound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {

            WeightedTransform target;
            target.transform = enemy.transform;
            target.weight = 1f;//MAGIC INT

            var sourceObjects = _multiAimConstraint.data.sourceObjects;//������ var

            sourceObjects.Insert(0, target);

            _multiAimConstraint.data.sourceObjects = sourceObjects;
            Debug.Log("OnTriggerEnter");
            _rigBuilder.Build();

            TargetFound?.Invoke(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            var sourceObjects = _multiAimConstraint.data.sourceObjects; //������ var
            sourceObjects.Clear();

            _multiAimConstraint.data.sourceObjects = sourceObjects;

            _rigBuilder.Build();
            Debug.Log("OnTriggerExit");//MAGIC INT
        }
    }
}