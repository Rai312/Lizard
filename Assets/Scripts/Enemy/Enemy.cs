using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Paintable))]
[RequireComponent(typeof(IceCubeExplosion))]//хороше бы жизнь отделить
[RequireComponent(typeof(TransformableOfEnemy))]
[RequireComponent(typeof(EnemyParticleController))]
public abstract class Enemy : MonoBehaviour
{
    //[SerializeField] private EnemyParticleController _particleController;
    [SerializeField] private int _health;
    //[SerializeField] private GameObject _startIceCube;
    //[SerializeField] private GameObject[] _cubes;

    private Paintable _paintable;
    private Animator _animator;
    private IceCubeExplosion _cubeExplosion;
    private TransformableOfEnemy _transformableOfEnemy;
    private EnemyParticleController _particleController;

    private void Awake()
    {
        _paintable = GetComponent<Paintable>();
        _animator = GetComponent<Animator>();
        _cubeExplosion = GetComponent<IceCubeExplosion>();
        _transformableOfEnemy = GetComponent<TransformableOfEnemy>();
        _particleController = GetComponent<EnemyParticleController>();
    }

    public event UnityAction Died;//операции с падением врага проход€т в DeathState
    public int Health => _health;
    public bool IsDead { get; private set; } = false;

    public void TakeDamage(int damage)
    {
        _health -= AffectDamage(damage);

        if (_health < 0)
            _health = 0;

        if (_health == 0)
        {
            Died?.Invoke();
            IsDead = true;//ћќ∆≈“ Ѕџ“№ —ƒ≈Ћј“№ ENEMY SKILL CONTROLLER
        }
    }

    protected virtual int AffectDamage(int damage)
    {
        return damage;
    }

    public void ApplyIceEffect()//дл€ покраски может быть отдельный слой paintable сделать
    {
        //_iceCube.gameObject.SetActive(true);
        //_animator.enabled = false;
        //_particleController.EnableIceExplosion();
        //Throw();
    }

    public void ApplyIceAttackEffect()
    {
        //_startIceCube.gameObject.SetActive(true);
        _animator.enabled = false;

        _particleController.EnableIceExplosion();
        _particleController.DisableFlashlight();

        _transformableOfEnemy.TossUp();
        _cubeExplosion.CreateExplosion();
        //Throw();
    }

    public void ApplyFireEffect()
    {
    }

    public void ApplyFireAttackEffect()
    {
        _animator.enabled = false;
        _particleController.DisableFlashlight();//может быть скилы сделать отдельным классом типо презентера
    }

    public void ApplyPoisoningEffect()
    {
        _paintable.PaintMaterial();
    }

    public void ApplyPoisoningAttackEffect()
    {
        _paintable.PaintMaterial();
        _particleController.DisableFlashlight();
    }

    //public void MakePhysical()//именнование посмотреть везде
    //{
    //    for (int i = 0; i < _rigidbodies.Length; i++)
    //    {
    //        _rigidbodies[i].isKinematic = false;
    //    }
    //}

    private void Throw()
    {
        //Sequence sequence = DOTween.Sequence();
        //sequence.AppendInterval(2.6f);//MAGIC INT
        ////MAGIC INT
        //Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + 40f, transform.position.z);
        ////MAGIC INT
        //sequence.AppendCallback(() =>
        //{
        //    MakePhysical();
        //    _cubeExplosion.CreateIceCubes(_cubes);
        //    _startIceCube.gameObject.SetActive(false);

        //    for (int i = 0; i < _rigidbodies.Length; i++)
        //    {
        //        sequence.Append(_rigidbodies[i].transform.DOMoveY(targetPosition.y, 1.5f));//MAGIC INT
        //    }
        //});
    }
}
