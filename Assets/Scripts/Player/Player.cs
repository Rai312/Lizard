using UnityEngine;

[RequireComponent(typeof(PlayerParticleController))]
public class Player : MonoBehaviour
{
    private PlayerParticleController _particleController;

    private void Start()
    {
        _particleController = GetComponent<PlayerParticleController>();
    }

    public void ApplyFireAttackEffect()
    {
        _particleController.EnableFireExplosion();
    }
}
