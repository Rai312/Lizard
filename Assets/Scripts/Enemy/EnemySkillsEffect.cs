using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Paintable))]
[RequireComponent(typeof(IceCubeExplosion))]
[RequireComponent(typeof(TransformableOfEnemy))]
[RequireComponent(typeof(EnemyParticleController))]
public class EnemySkillsEffect : MonoBehaviour
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
        _particleController = GetComponent<EnemyParticleController>();//абстракция
    }

    public void ApplyIceAttackEffect()
    {
        _animator.enabled = false;

        _particleController.EnableIceExplosion();
        _particleController.DisableFlashlight();

        _transformableOfEnemy.TossUp();
        _cubeExplosion.CreateExplosion();
    }

    public void ApplyFireAttackEffect()
    {
        _animator.enabled = false;
        _particleController.DisableFlashlight();

        _transformableOfEnemy.PullToPlayer();
        Physics.IgnoreLayerCollision(6, 9, false);//MAGIC INT
        Physics.IgnoreLayerCollision(7, 9, false);//MAGIC INT
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
