using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	[SerializeField] private float _speed;//если есть стир спид, то этот тоже как то назвать
	[SerializeField] private float _steerSpeed;
	[SerializeField] private Joystick _joystick;

	//private RaycastHit _raycast;
	private Rigidbody _rigidbody;
	private Vector3 _normal;
	private Vector3 _direction;
	public bool _isWall = false;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		float h = _joystick.Direction.x;
		float v = _joystick.Direction.y;

		Move();
	}

    private void OnCollisionStay(Collision collision)
    {
		_normal = collision.contacts[0].normal;

	}

    private void Move()
	{
		Debug.Log(_normal);
		float horizontal = _joystick.Direction.x;
		float vertical = _joystick.Direction.y;

		if (_isWall)
		{
			_direction = new Vector3(Vector3.zero.y, -horizontal, vertical);
		}
		else
		{
			_direction = new Vector3(horizontal, Vector3.zero.y, vertical);
		}

		Vector3 directionAlongSurface = (_direction - Vector3.Dot(_direction, _normal) * _normal).normalized;
		Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);
		

		_rigidbody.MovePosition(_rigidbody.position + offset);//можно попробовать по другому двигать боди чтобы пользовать kinematic

		//transform.Rotate(Vector3.up * horizontal * _steerSpeed * Time.deltaTime);
	}
}
