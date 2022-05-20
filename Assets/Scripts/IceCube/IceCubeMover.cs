using UnityEngine;
using DG.Tweening;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class IceCubeMover : MonoBehaviour
{
    [SerializeField] private float _delayBeforeMovement = 4.25f;
    [SerializeField] private float _durationMovement = 0.55f;


    private Vector3 _startPosition;
    //private Rigidbody _rigidbody;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    public void MoveAfterFalling()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_delayBeforeMovement);
        sequence.Append(transform.DOMove(_startPosition, _durationMovement));
    }
}
