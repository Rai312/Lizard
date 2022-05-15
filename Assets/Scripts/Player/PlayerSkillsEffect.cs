using UnityEngine;

[RequireComponent(typeof(PlayerScaler))]
public class PlayerSkillsEffect : SkillsEffect
{
    [SerializeField] private MeshChanger _meshChanger;

    private PlayerScaler _playerScaler;
    private PlayerParticleController _particleController;

    private void Awake()
    {
        _playerScaler = GetComponent<PlayerScaler>();
        _particleController = GetComponent<PlayerParticleController>();
    }

    public override void ApplyFireAttackEffect()
    {
        _meshChanger.ChangeMesh();
        _playerScaler.Scale();
        _particleController.EnableFireExplosion();
    }
}
