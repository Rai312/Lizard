using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScan : MonoBehaviour
{
    [SerializeField] private float _steerSpeed;
    [SerializeField] private Joystick _joystick;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up* _joystick.Direction.x * _steerSpeed * Time.deltaTime);
        //��� ���� ��������� ���� � ������������ ������� ������� ���������� � ��������� �������
    }
}
