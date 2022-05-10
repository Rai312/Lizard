using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    //[SerializeField] private TransformableOfEnemy _transformableOfEnemy;
    [SerializeField] private Material _bodyMaterial;
    [SerializeField] private Color _iceTargetColor;
    [SerializeField] private Color _fireTargetColor;
    [SerializeField] private Color _poisonTargetColor;
    [SerializeField] private Color _startColor;//сделать потом ресет
    [SerializeField] private GameObject _iceCube;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ParticleSystem _particleSystem2;
    [SerializeField] private ParticleSystem _particleSystem3;
    [SerializeField] private ParticleSystem _particleSystem4;
    [SerializeField] private float _speed;
    [SerializeField] private CubeExplosion _cubeExplosion;
    [SerializeField] private GameObject[] _cubes;
    [SerializeField] private ParticleSystem _particleSystem5;
    [SerializeField] private ParticleSystem _particleSystem6;
    [SerializeField] private ParticleSystem _particleSystem7;
    [SerializeField] private ParticleSystem _particleSystem8;

    private void Awake()
    {
        _bodyMaterial.color = _startColor;
    }

    public event UnityAction Died;
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
            IsDead = true;
        }
    }

    protected virtual int AffectDamage(int damage)
    {
        return damage;
    }

    public void ApplyIceEffect()//для покраски может быть отдельный слой paintable сделать
    {
        _iceCube.gameObject.SetActive(true);
        _bodyMaterial.color = _iceTargetColor;
        _animator.enabled = false;
        _particleSystem.Play();
        _particleSystem2.Play();
        _particleSystem3.Play();
        _particleSystem4.Play();
        //MakePhysical();
        Throw();
    }

    public void ApplyFireEffect()
    {
        _bodyMaterial.color = _fireTargetColor;
    }

    public void ApplyPoisoningEffect()
    {
        _bodyMaterial.color = _poisonTargetColor;
    }

    public void MakePhysical()
    {
        //_animator.enabled = false;
        _particleSystem5.gameObject.SetActive(false);
        _particleSystem6.gameObject.SetActive(false);
        _particleSystem7.gameObject.SetActive(false);
        _particleSystem8.gameObject.SetActive(false);
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
        _cubeExplosion.CreateCube(_cubes);
        _iceCube.gameObject.SetActive(false);
    }

    private void Throw()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(2.6f);
        
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + 40f, transform.position.z);

        sequence.AppendCallback(() =>
        {
            MakePhysical();
            for (int i = 0; i < _rigidbodies.Length; i++)
            {
                sequence.Append(_rigidbodies[i].transform.DOMoveY(targetPosition.y, 1.5f));
            }
        });
    }
}
