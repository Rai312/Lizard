using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(EnemyAnimationController))]
[RequireComponent(typeof(Enemy))]
public class PatrolState : State
{
    [SerializeField] private float _pathLengthZ = 40f;

    private EnemyAnimationController _enemyAnimationController;
    private Enemy _enemy;
    private Vector3 _targetRotation = new Vector3(0, 180f, 0);
    private Sequence _sequence;
    private float _durationMove = 5f;
    private float _durationRotate = 3.5f;
    private float _waitingTimeBeforeRotate = 5.2f;
    private float _waitingTimeBeforeMove = 0.3f;

    private void Awake()
    {
        _enemyAnimationController = GetComponent<EnemyAnimationController>();
        _enemy = GetComponent<Enemy>();
        DOTween.Init();
    }

    private void OnEnable()
    {
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
    }

    private void Start()
    {
        _sequence = DOTween.Sequence();

        Patrol(-_pathLengthZ, Vector3.zero);
        Patrol(_pathLengthZ, _targetRotation);

        _sequence.SetLoops(-1, LoopType.Restart);
    }

    private void Patrol(float pathLenghtZ, Vector3 targetRotation)
    {
        _sequence.Append(transform.DOMoveZ(pathLenghtZ, _durationMove).SetRelative().SetEase(Ease.Linear));
        _sequence.AppendCallback(() =>
        {
            _enemyAnimationController.Idle();
        });

        _sequence.AppendInterval(_waitingTimeBeforeRotate);
        _sequence.Append(transform.DORotate(targetRotation, _durationRotate));

        _sequence.AppendInterval(_waitingTimeBeforeMove);
        _sequence.AppendCallback(() =>
        {
            _enemyAnimationController.Move();
        });
    }

    private void OnDied()
    {
        Debug.Log("OnDied");
        _sequence.Kill();
    }
}
