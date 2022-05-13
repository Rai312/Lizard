using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IceCubeExplosion : MonoBehaviour
{
    [SerializeField] private float _delayBeforeExplosion = 2.6f;
    [SerializeField] private float _force = 300f;
    [SerializeField] private float _radius = 2f;
    [SerializeField] private GameObject _startIceCube;
    [SerializeField] private GameObject[] _iceCubes;

    //private void Start()
    //{
    //    _startIceCube.gameObject.SetActive(false);
    //}

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
                _iceCubes[i].GetComponent<IceCubeMover>().Move();
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
        }
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
