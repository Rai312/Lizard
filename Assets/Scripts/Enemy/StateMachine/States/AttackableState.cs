using System;
using UnityEngine;

public class AttackableState : State
{
    [SerializeField] private TransformableOfEnemy _transformableOfEnemy;
    [SerializeField] private Material _bodyMaterial;
    [SerializeField] private Color _targetColor;
    [SerializeField] private Color _startColor;//������� ����� �����

    //public Color _startColor;//�����������
    //1. ������ ����������� ��� ������
    //1. ������ ����������� �� �����-����� ������� ������� ����� � ���������

    //2. ������ ������� ����� � ����, �� �� �������

    //3. ������ �������� ��������
    //3. ���� ��������

    //����� ��� ���������� ����� ���� ��� �����������

    //���� �������� ������ ���� �� ��� �������� ��������� �������,
    //����� ������ ��������� � ��� ������ ��� ���?

    private void Awake()
    {
        _bodyMaterial.color = _startColor;
    }

    private void Start()
    {
        //Debug.Log("ApplyPoisoningEffect");
        ApplyPoisoningEffect();
    }
    
    //�������� ����� �������� ��� 

    private void ApplyPoisoningEffect()
    {
        _bodyMaterial.color = _targetColor;
    }

    private void ApplyIceEffect()
    {
        _bodyMaterial.color = _targetColor;
    }

    private void ApplyFireEffect()
    {
        _bodyMaterial.color = _targetColor;
    }



    //�� ����� ���������� ������� � ��� ����������� � ������ ����� � ���� ����� ���� � ������� attackHandler
    //� ����� ��� ������������ ���������� ���������� ����� �� �����
}
