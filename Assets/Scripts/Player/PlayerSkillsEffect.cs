using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PlayerScaler))]
[RequireComponent(typeof(PlayerParticleController))]
public class PlayerSkillsEffect : MonoBehaviour
{
    [SerializeField] private MeshChanger _meshChanger;

    //private PlayerScaler _playerScaler;
    private PlayerParticleController _particleController;//����������

    private void Awake()
    {
        //_playerScaler = GetComponent<PlayerScaler>();
        _particleController = GetComponent<PlayerParticleController>();
    }

    public void ApplyFireAttackEffect()//���������
    {
        _meshChanger.ChangeMesh();
        //_playerScaler.Scale();
        _particleController.EnableFireExplosion();
    }
}
