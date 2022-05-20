using UnityEngine;

[RequireComponent(typeof(PlayerScaler))]
public class PlayerSkillsEffect : SkillsEffect
{
    [SerializeField] private MeshChanger _meshHeadChanger;
    [SerializeField] private MeshChanger _meshLegsChanger;
    [SerializeField] private MeshChanger _meshSpineChanger;

    private PlayerScaler _playerScaler;
    private PlayerParticleController _particleController;

    private void Awake()
    {
        _playerScaler = GetComponent<PlayerScaler>();
        _particleController = GetComponent<PlayerParticleController>();
    }

    public override void ApplyFireAttackEffect()
    {
        _meshHeadChanger.ChangeMesh();
        _meshLegsChanger.ChangeMesh();
        _meshSpineChanger.ChangeMesh();
        _playerScaler.Scale();
        _particleController.EnableFireExplosion();
    }
}
