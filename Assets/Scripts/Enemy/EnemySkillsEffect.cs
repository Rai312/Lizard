using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Paintable))]
[RequireComponent(typeof(IceCubeExplosion))]
[RequireComponent(typeof(TransformableOfEnemy))]
public class EnemySkillsEffect : SkillsEffect
{
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

    public void ApplyIceAttackEffect()
    {
        _animator.enabled = false;

        _particleController.EnableIceExplosion();
        _particleController.DisableFlashlight();

        _transformableOfEnemy.TossUp();
        _cubeExplosion.CreateExplosion();
    }

    public override void ApplyFireAttackEffect()
    {
        _animator.enabled = false;
        _particleController.DisableFlashlight();

        _transformableOfEnemy.PullToPlayer();
    }

    public void ApplyPoisoningAttackEffect()
    {
        _animator.enabled = false;
        _particleController.EnablePoisonExplosion();
        _particleController.DisableFlashlight();

        _transformableOfEnemy.Drop();
        _paintable.PaintMaterial();
    }
}
