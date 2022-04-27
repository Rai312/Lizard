using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DeathState : State
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _rigidbodies;//����� ���� ������� ����������� c Dotween ����� ���������� ���

    //private void Awake()
    //{
    //    for (int i = 0; i < _rigidbodies.Length; i++)
    //    {
    //        _rigidbodies[i].isKinematic = false;//��� ������ ���� � ������� ������� � �����
    //    }
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakePhysical();
        }
    }

    private void MakePhysical()
    {
        _animator.enabled = false;

        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
    }
}
