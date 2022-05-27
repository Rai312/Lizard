using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LookAt : MonoBehaviour
{
    [SerializeField] private AimConstraint _aimConstraint;

    private float _minValueWeight = 0f;
    private float _maxValueWeight = 1f;
    private Coroutine _rotateToStartPositionInJob;
    private float _durationSmoothingRotation = 1.5f;
    private float _durationWaitAfterAttack = 1.4f;
    private float _elapsedTime = 0f;
    private List<Enemy> _sourceEnemies;
    private List<float> _distances;

    public event UnityAction TargetFound;
    public event UnityAction TargetLost;

    private void Awake()
    {
        _sourceEnemies = new List<Enemy>(_aimConstraint.sourceCount);
    }

    private void Start()
    {
        _distances = new List<float>();

        for (int i = 0; i < _aimConstraint.sourceCount; i++)
        {
            _distances.Add(Vector3.Distance(_aimConstraint.GetSource(i).sourceTransform.position, transform.position));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (enemy.IsDead == false)
            {
                if (_rotateToStartPositionInJob != null)
                    StopCoroutine(_rotateToStartPositionInJob);

                enemy.Died += OnDied;

                _sourceEnemies.Add(enemy);

                for (int i = 0; i < _aimConstraint.sourceCount; i++)
                {
                    if (_aimConstraint.GetSource(i).sourceTransform == enemy.transform)
                    {
                        ConstraintSource target = _aimConstraint.GetSource(i);
                        target.weight = 1;
                        _aimConstraint.SetSource(i, target);
                    }
                }
                TargetFound?.Invoke();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (_sourceEnemies.Count > 1)
            {
                float minDistance = GetModifiedDistances(_distances).Min();
                int index = GetModifiedDistances(_distances).IndexOf(minDistance);

                for (int i = 0; i < _aimConstraint.sourceCount; i++)
                {
                    if (index == i)
                    {
                        ChangeTarget(i);
                    }
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Died -= OnDied;

            _sourceEnemies.Remove(enemy);

            for (int i = 0; i < _aimConstraint.sourceCount; i++)
            {
                if (enemy.transform == _aimConstraint.GetSource(i).sourceTransform)
                {
                    SetTarget(i);
                }
            }

            TargetLost?.Invoke();
        }
    }

    private void OnDied(Enemy enemy)
    {
        for (int i = 0; i < _aimConstraint.sourceCount; i++)
        {
            if (enemy.transform == _aimConstraint.GetSource(i).sourceTransform)
            {
                _rotateToStartPositionInJob = StartCoroutine(RotateToStartPosition(_durationSmoothingRotation, i, _durationWaitAfterAttack));
            }
        }
    }

    private IEnumerator RotateToStartPosition(float durationRotate, int index, float durationWaitAfterAttack = 0)
    {
        yield return new WaitForSeconds(durationWaitAfterAttack);

        while (_elapsedTime < durationRotate)
        {
            _elapsedTime += Time.deltaTime;
            _aimConstraint.weight = Mathf.Lerp(_aimConstraint.weight, _minValueWeight, _elapsedTime / durationRotate);

            yield return null;
        }
        _aimConstraint.RemoveSource(index);

        _aimConstraint.weight = _maxValueWeight;
        _elapsedTime = 0;
    }

    private List<float> GetModifiedDistances(List<float> distances)
    {
        for (int i = 0; i < _aimConstraint.sourceCount; i++)
        {
            distances[i] = Vector3.Distance(_aimConstraint.GetSource(i).sourceTransform.position, transform.position);
        }
        return distances;
    }

    private void ChangeTarget(int indexTarget)
    {
        ConstraintSource target = _aimConstraint.GetSource(indexTarget);

        for (int i = 0; i < _aimConstraint.sourceCount; i++)
        {
            SetTarget(i);

            if (indexTarget == i)
            {
                target.weight = _maxValueWeight;
                _aimConstraint.SetSource(i, target);
            }
        }
    }

    private void SetTarget(int indexSetTarget)
    {
        ConstraintSource retarget = _aimConstraint.GetSource(indexSetTarget);
        retarget.weight = _minValueWeight;
        _aimConstraint.SetSource(indexSetTarget, retarget);
    }
}
