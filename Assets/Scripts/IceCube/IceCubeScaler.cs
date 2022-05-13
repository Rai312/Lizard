using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IceCubeScaler : MonoBehaviour
{
    [SerializeField] private float _durationScaling = 1.2f;
    [SerializeField] private float _targetScale = 0f;
    [SerializeField] private float _delayBeforeMovement = 4.25f;

    public void Scale()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_delayBeforeMovement);
        sequence.Append(transform.DOScale(_targetScale, _durationScaling));
    }
}
