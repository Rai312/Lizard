using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Enemy))]
public class PatrolState : State
{
    [SerializeField] private float _pathLengthZ = 40f;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private EnemyAnimationController _enemyAnimationController;
    [SerializeField] private Player _player;

    private Enemy _enemy;

    private Vector3 _targetPosition;//нужно наверно сделать какой то общий класс патрулирования или что такое, может быть по типу transformable
    private float _firstPointZ;
    private float _secondPointZ;
    private Sequence _sequence;
    private float _dirationMove = 5f;

    private void Awake()
    {
        DOTween.Init();
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
    }

    private void OnDied()
    {
        _sequence.Kill();
    }

    private void Start()
    {
        _targetPosition = transform.position;
        _firstPointZ = transform.position.z;
        _secondPointZ = _firstPointZ + _pathLengthZ;

        _sequence = DOTween.Sequence();

        _sequence.Append(transform.DOMoveZ(-_pathLengthZ, _dirationMove).SetRelative().SetEase(Ease.Linear));

        _sequence.AppendCallback(() =>
        {
            _enemyAnimationController.Idle();
        });

        _sequence.AppendInterval(4f);
        //Debug.Log("_sequence.Append(transform.DORotate(new Vector3(0, 0, 0), 4f));");
        _sequence.Append(transform.DORotate(new Vector3(0, 0, 0), 3.5f));
        //_sequence.AppendInterval(1f);

        _sequence.AppendCallback(() =>
        {
            _enemyAnimationController.Move();
        });
        _sequence.Append(transform.DOMoveZ(_pathLengthZ, _dirationMove).SetRelative().SetEase(Ease.Linear));

        _sequence.AppendCallback(() =>
        {
            _enemyAnimationController.Idle();//Rename
        });

        _sequence.AppendInterval(5f);
        _sequence.Append(transform.DORotate(new Vector3(0, 180f, 0), 4f));
        _sequence.AppendInterval(1f);

        _sequence.AppendCallback(() =>
        {
            _enemyAnimationController.Move();
        });

        _sequence.SetLoops(-1, LoopType.Restart);
    }
}
