using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;
using System.Collections;

public class LookAt : MonoBehaviour
{
    [SerializeField] private AimConstraint _aimConstraint;

    private float _targetWeight = 1f;
    private int indexOfRemoveTargetObject = 0;
    private Coroutine _rotateToStartPositionInJob;
    private float _minValueWeight = 0;
    private float _durationSmoothingRotation = 3f;
    private float _durationWaitAfterAttack = 1.4f;
    private float _elapsedTime = 0f;

    public event UnityAction TargetFound;
    public event UnityAction TargetLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (enemy.IsDead == false)
            {
                if (_rotateToStartPositionInJob != null)
                    StopCoroutine(_rotateToStartPositionInJob);

                enemy.Died += OnDied;

                _aimConstraint.weight = 1;
                ConstraintSource target = new ConstraintSource();
                target.sourceTransform = enemy.transform;
                target.weight = _targetWeight;

                TryRemoveSources();

                _aimConstraint.AddSource(target);

                TargetFound?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Died -= OnDied;

            TargetLost?.Invoke();
            _rotateToStartPositionInJob = StartCoroutine(RotateToStartPosition(_durationSmoothingRotation));
        }
    }

    private void OnDied()
    {
        TargetLost?.Invoke();
        _rotateToStartPositionInJob = StartCoroutine(RotateToStartPosition(_durationSmoothingRotation, _durationWaitAfterAttack));
    }

    private IEnumerator RotateToStartPosition(float durationRotate, float durationWaitAfterAttack = 0f)
    {
        yield return new WaitForSeconds(durationWaitAfterAttack);

        while (_elapsedTime < durationRotate)
        {
            _elapsedTime += Time.deltaTime;
            _aimConstraint.weight = Mathf.Lerp(_aimConstraint.weight, _minValueWeight, _elapsedTime / durationRotate);

            yield return null;
        }
        _elapsedTime = 0;
    }

    private void TryRemoveSources()
    {
        if (_aimConstraint.sourceCount > 0)
            for (int i = 0; i < _aimConstraint.sourceCount; i++)
                _aimConstraint.RemoveSource(i);
    }
}
