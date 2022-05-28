using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HeadController : MonoBehaviour
{
    [SerializeField] private AimConstraint _aimConstraint;

    private float _minValueWeight = 0f;
    private float _maxValueWeight = 1f;
    private Coroutine _rotateToStartPositionInJob;
    private float _durationSmoothingRotation = 1.5f;
    private float _durationWaitAfterAttack = 1.2f;
    private float _elapsedTime = 0f;
    private List<Enemy> _sourceEnemies;
    private List<float> _distances;
    private int _minimumNumberOfEnemiesToSwitch = 1;

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

    public void SwitchTarget()
    {
        if (_sourceEnemies.Count > _minimumNumberOfEnemiesToSwitch)
        {
            ChangeDistances();

            float minDistance = _distances.Min();
            int index = _distances.IndexOf(minDistance);

            for (int i = 0; i < _aimConstraint.sourceCount; i++)
            {
                if (index == i)
                {
                    SetTarget(i);
                }
            }
        }
    }

    public void EnableLookAt(Enemy enemy)
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
                    ChangeWeight(i, _maxValueWeight);
                }
            }
            TargetFound?.Invoke();
        }
    }

    public void DisableLookAt(Enemy enemy)
    {
        enemy.Died -= OnDied;

        _sourceEnemies.Remove(enemy);

        for (int i = 0; i < _aimConstraint.sourceCount; i++)
        {
            if (enemy.transform == _aimConstraint.GetSource(i).sourceTransform)
            {
                ChangeWeight(i, _minValueWeight);
            }
        }

        TargetLost?.Invoke();
    }    

    private void ChangeDistances()
    {
        for (int i = 0; i < _aimConstraint.sourceCount; i++)
        {
            _distances[i] = Vector3.Distance(_aimConstraint.GetSource(i).sourceTransform.position, transform.position);
        }
    }

    private void SetTarget(int indexTarget)
    {
        ConstraintSource target = _aimConstraint.GetSource(indexTarget);

        for (int i = 0; i < _aimConstraint.sourceCount; i++)
        {
            ChangeWeight(i, _minValueWeight);

            if (indexTarget == i)
            {
                target.weight = _maxValueWeight;
                _aimConstraint.SetSource(i, target);
            }
        }
    }

    private void ChangeWeight(int indexSource, float weight)
    {
        ConstraintSource retarget = _aimConstraint.GetSource(indexSource);
        retarget.weight = weight;
        _aimConstraint.SetSource(indexSource, retarget);
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
}
