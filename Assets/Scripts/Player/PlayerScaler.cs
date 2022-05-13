using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScaler : MonoBehaviour
{
    [SerializeField] private float _targetScale = 2.5f;
    [SerializeField] private float _durationScaling = 0.5f;

    public void Scale()
    {
        transform.DOScale(_targetScale, _durationScaling);
    }
}
