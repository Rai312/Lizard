using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IceCubeMover : MonoBehaviour
{
    //[SerializeField] private Transform _startTransform;
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
        //_startPosition = transform.position;
    }

    private void OnEnable()
    {
        
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(5f);
        sequence.AppendCallback(() =>
        {
            Debug.Log("sequence;");
            sequence.Append(transform.DOScale(0f, 1.2f));
        });
        sequence.Append(transform.DOMove(_startPosition, 0.8f));
    }
}
