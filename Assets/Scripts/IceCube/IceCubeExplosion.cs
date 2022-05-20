using UnityEngine;
using DG.Tweening;
using System.Collections;

public class IceCubeExplosion : MonoBehaviour
{
    [SerializeField] private float _delayBeforeExplosion = 2.6f;
    [SerializeField] private float _force = 300f;
    [SerializeField] private float _radius = 2f;
    [SerializeField] private GameObject _startIceCube;
    [SerializeField] private GameObject[] _iceCubes;

    private float _elapsedTime = 0;
    private Coroutine _fadeDragInJob;
    //private Coroutine _fadeDecreaseDragInJob;
    private float _durationIncreaseFading = 0.4f;
    private float _delayBeforeIncreaseFading = 0.4f;
    private float _durationDecreaseFading = 0.8f;
    private float _delayBeforeDecreaseFading = 0.8f;
    private float _targetMinDragValue = 0f;
    private float _targetMaxDragValue = 4.5f;
    //private float _durationIncreaseFading = 1.0f;
    //private float _delayBeforeIncreaseFading = 1.0f;
    //private float _durationDecreaseFading = 2f;
    //private float _delayBeforeDecreaseFading = 2f;

    public void CreateExplosion()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendCallback(() =>
        {
            EnableStartIceCube();
        });

        sequence.AppendInterval(_delayBeforeExplosion);

        sequence.AppendCallback(() =>
        {
            CreateIceCubes(_iceCubes);
            DisableStartIceCube();

            for (int i = 0; i < _iceCubes.Length; i++)
            {
                _iceCubes[i].GetComponent<Rigidbody>().AddExplosionForce(_force, transform.position, _radius);
                _iceCubes[i].GetComponent<IceCubeMover>().MoveAfterFalling();
                _iceCubes[i].GetComponent<IceCubeScaler>().Scale();
            }
        });
    }

    private void CreateIceCubes(GameObject[] iceCubes)
    {
        for (int i = 0; i < _iceCubes.Length; i++)
        {
            iceCubes[i].gameObject.SetActive(true);
            iceCubes[i].GetComponent<Rigidbody>().isKinematic = false;

            InfluenceToDrag(iceCubes[i].GetComponent<Rigidbody>());
        }
    }

    private void InfluenceToDrag(Rigidbody rigidbody)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendCallback(() =>
        {
            _fadeDragInJob = StartCoroutine(FadeDrag(rigidbody, _durationIncreaseFading, _targetMaxDragValue));
        });

        sequence.AppendInterval(_delayBeforeIncreaseFading);
        sequence.AppendCallback(() =>
        {
            StopCoroutine(_fadeDragInJob);
        });

        sequence.AppendInterval(_delayBeforeIncreaseFading);
        sequence.AppendCallback(() =>
        {
            _fadeDragInJob = StartCoroutine(FadeDrag(rigidbody, _durationDecreaseFading, _targetMinDragValue));
        });

        sequence.AppendInterval(_delayBeforeDecreaseFading);
        sequence.AppendCallback(() =>
        {
            StopCoroutine(_fadeDragInJob);
        });
    }

    private IEnumerator FadeDrag(Rigidbody rigidbody, float durationFading, float targetDragValue)
    {
        while (_elapsedTime < durationFading)
        {
            _elapsedTime += Time.deltaTime;
            rigidbody.drag = Mathf.Lerp(rigidbody.drag, targetDragValue, _elapsedTime / durationFading);
            yield return null;
        }
        _elapsedTime = 0f;
    }

    private void DisableStartIceCube()
    {
        _startIceCube.gameObject.SetActive(false);
    }

    private void EnableStartIceCube()
    {
        _startIceCube.gameObject.SetActive(true);
    }
}
