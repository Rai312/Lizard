using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;
using DG.Tweening;
using System.Collections;

public class LookAt : MonoBehaviour
{
    [SerializeField] private AimConstraint _aimConstraint;

    private float _targetWeight = 1f;
    private Coroutine _coroutine;//Rename;

    public event UnityAction TargetFound;
    public event UnityAction TargetLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (enemy.IsDead == false)
            {
                if (_coroutine != null)
                    StopCoroutine(_coroutine);

                enemy.Died += OnDied;

                _aimConstraint.weight = 1;
                ConstraintSource target = new ConstraintSource();
                target.sourceTransform = enemy.transform;
                target.weight = _targetWeight;
                _aimConstraint.AddSource(target);

                TargetFound?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Died -= OnDied;//����� sourceObject �������������

            

            TargetLost?.Invoke();
            _coroutine = StartCoroutine(SetStartRotation());
        }
    }

    private void OnDied()//����������
    {
        //_aimConstraint.weight = 0;
        //_aimConstraint.RemoveSource(0);//MAGIC INT � �������� ����� ������ ������
        //SetStartRotation();
        _coroutine = StartCoroutine(SetStartRotation());
    }

    //private void SetStartRotation()
    //{

    //    Debug.Log("SetStartRotation");
    //    Quaternion targetRotation = new Quaternion(0, 0, 0, 1);

    //    transform.DORotateQuaternion(targetRotation, 8f).WaitForKill();
    //}

    private IEnumerator SetStartRotation()//rename
    {
        float duration = 2f;
        float elapsed = 0;

        while (elapsed < duration)
        {
            Debug.Log(elapsed + "elapsed");
            Debug.Log(elapsed / duration + "elapsed / duration");//����� ������ ������� ������ �������� 
            elapsed += Time.deltaTime;
            _aimConstraint.weight = Mathf.Lerp(_aimConstraint.weight, 0, elapsed / duration);

            if (_aimConstraint.weight == 0)
                _aimConstraint.RemoveSource(0);//MAGIC INT

            yield return null;
        }

        //MAGIC INT
        Debug.Log("_aimConstraint.RemoveSource(0)");
    }
}
