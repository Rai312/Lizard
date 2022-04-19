using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PatrolState : MonoBehaviour
{
    [SerializeField] private float _pathLengthZ = 40f;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private EnemyAnimationController _enemyAnimationController;

    private Vector3 _targetPosition;//нужно наверно сделать какой то общий класс патрулирования или что такое, может быть по типу transformable
    private float _firstPointZ;
    private float _secondPointZ;
    private Sequence _sequence;
    private float _dirationMove = 5f;

    private void Start()
    {
        _targetPosition = transform.position;
        _firstPointZ = transform.position.z;
        _secondPointZ = _firstPointZ + _pathLengthZ;

        _sequence = DOTween.Sequence();

        _sequence.Append(transform.DOMoveZ(-_pathLengthZ, _dirationMove).SetRelative().SetEase(Ease.Linear));

        _sequence.AppendCallback(() =>
        {
            _enemyAnimationController.CheckPosition();
        });

        _sequence.AppendInterval(1f);
        //Debug.Log("_sequence.Append(transform.DORotate(new Vector3(0, 0, 0), 4f));");
        _sequence.Append(transform.DORotate(new Vector3(0, 0, 0), 4f));
        _sequence.AppendInterval(1f);

        _sequence.AppendCallback(() =>
        {
            _enemyAnimationController.Move();
        });
        _sequence.Append(transform.DOMoveZ(_pathLengthZ, _dirationMove).SetRelative().SetEase(Ease.Linear));

        _sequence.AppendCallback(() =>
        {
            _enemyAnimationController.CheckPositionHipHop();
        });

        _sequence.AppendInterval(1f);
        _sequence.Append(transform.DORotate(new Vector3(0, 180f, 0), 4f));
        _sequence.AppendInterval(1f);

        _sequence.AppendCallback(() =>
        {
            _enemyAnimationController.Move();
        });

        _sequence.SetLoops(-1, LoopType.Restart);
    }

    private void Update()
    {
        //_targetPosition = TryGetNextTargetPosition(_targetPosition);
        //Move(_targetPosition);
    }

    //private void Move(Vector3 targetPosition)//функция должна работать только с тем что она принимает
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _speed);
    //}

    //private Vector3 TryGetNextTargetPosition(Vector3 targetPosition)//функция должна работать только с тем что она принимает
    //{
    //    if (transform.position.z >= _firstPoint.z)
    //        targetPosition = _secondPoint;
    //    else if (transform.position.z <= _secondPoint.z)
    //        targetPosition = _firstPoint;

    //    return targetPosition;
    //}

    //private void WaitBeforeMoving()
    //{

    //}
}
