using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransformableOfEnemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private float _heightTossUp = 40f;
    [SerializeField] private float _durationTossUp = 1.5f;
    [SerializeField] private float _durationPullToPlayer = 1.0f;
    [SerializeField] private float _delayBeforeTossUp = 2.6f;

    private Vector3 _targetPosition;
    private int _indexOfFirstRigidbody = 0;
    private int _indexOfSecondRigidbody = 1;

    public void TossUp()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(_delayBeforeTossUp);
        _targetPosition = new Vector3(transform.position.x, transform.position.y + _heightTossUp, transform.position.z);

        sequence.AppendCallback(() =>
        {
            MakePhysical();

            for (int i = 0; i < _rigidbodies.Length; i++)
            {
                sequence.Append(_rigidbodies[i].transform.DOMoveY(_targetPosition.y, _durationTossUp));
            }
        });
    }

    public void PullToPlayer()
    {
        Sequence sequence = DOTween.Sequence();

        _targetPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);

        sequence.AppendCallback(() =>
        {
            MakePhysical();

            sequence.Append(_rigidbodies[_indexOfFirstRigidbody].transform.DOMoveZ(_targetPosition.z, _durationPullToPlayer));
            sequence.Append(_rigidbodies[_indexOfSecondRigidbody].transform.DOMoveX(_targetPosition.x, _durationPullToPlayer));
        }
        );
    }

    public void Drop()
    {
        MakePhysical();
    }

    private void MakePhysical()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
    }
}
