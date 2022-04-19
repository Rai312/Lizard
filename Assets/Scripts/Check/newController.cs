using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newController : MonoBehaviour
{
    IguanaCharacter iguanaCharacter;
    [SerializeField] private float _steerSpeed = 180;
    [SerializeField] private float _bodySpeed = 5;
    [SerializeField] private int _gap = 10;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;
    //[SerializeField] private Rigidbody _rigidbodyChild;

    private Rigidbody _rigidbody;
    private Vector3 _normal;
    private Vector3 _direction;
    private RaycastHit _hit;

    //public GameObject _bodyPrefab;

    private List<GameObject> _bodyParts = new List<GameObject>();
    private List<Vector3> _positionsHistory = new List<Vector3>();
    public bool _isWall = false;

    private void Awake()
    {
        iguanaCharacter = GetComponent<IguanaCharacter>();
        _rigidbody = GetComponent<Rigidbody>();

    }

    void Start()
    {
        //GrowSnake();
        //GrowSnake();
        //GrowSnake();
        //GrowSnake();
    }

    void Update()
    {

        float h = _joystick.Direction.x;
        float v = _joystick.Direction.y;

        Debug.Log(h);
        Debug.Log(v);

        iguanaCharacter.Move(v, h);

        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        Move();
        //Vector3 targetPosition = new Vector3(transform.position.x + _joystick.Direction.x, Vector3.zero.y, transform.position.z + _joystick.Direction.y);

        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        //float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        transform.Rotate(Vector3.up * steerDirection * _steerSpeed * Time.deltaTime);

        _positionsHistory.Insert(0, transform.position);

        int index = 0;
        foreach (var body in _bodyParts)
        {
            Vector3 point = _positionsHistory[Mathf.Clamp(index * _gap, 0, _positionsHistory.Count - 1)];

            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * _bodySpeed * Time.deltaTime;

            body.transform.LookAt(point);//������� LookAt

            index++;
        }
    }

    private void OnCollisionStay(Collision collision)//������ ���� ������� ����� ������� �� �����, �� �� ����� �������� ����� rigidbody, � ����� transformPosition
    {// ��������� �������� �� � ������ ������� �������
        if (collision.collider.TryGetComponent<SurfaceToMove>(out SurfaceToMove surfaceToMove))
        {
            _normal = collision.contacts[0].normal;
            Debug.Log("OnCollisionStay");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent<SurfaceToMove>(out SurfaceToMove surfaceToMove))
        {

        }
    }
    //���� normal �� ������� ����������� �� ����� ��������� �� ��� ���� �� ������ �����������
    private void Move()
    {
        //_normal = 
        //Debug.Log(_normal);
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

        Vector3 targetPosition = transform.position + offset;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        //_rigidbody.MovePosition(_rigidbody.position + offset);//����� ����������� �� ������� ������� ���� ����� ���������� kinematic

        //transform.Rotate(Vector3.up * horizontal * _steerSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + _normal * 50);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (_direction - Vector3.Dot(_direction, _normal) * _normal) * 50);
    }

    //private void GrowSnake()
    //{
    //    GameObject body = Instantiate(_bodyPrefab);
    //    _bodyParts.Add(body);
    //}


}
