using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransformableOfEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private float _heightTossUp = 40f;
    [SerializeField] private float _durationTossUp = 1.5f;
    [SerializeField] private float _delayBeforeTossUp = 2.6f;

    public void TossUp()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(_delayBeforeTossUp);

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + _heightTossUp, transform.position.z);
        //Debug.Log(targetPosition);
        sequence.AppendCallback(() =>
        {
            MakePhysical();

            for (int i = 0; i < _rigidbodies.Length; i++)
            {
                sequence.Append(_rigidbodies[i].transform.DOMoveY(targetPosition.y, _durationTossUp));
            }
        });
    }

    private void MakePhysical()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
    }
}
