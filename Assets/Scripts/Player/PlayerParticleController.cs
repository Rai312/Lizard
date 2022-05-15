using UnityEngine;

public class PlayerParticleController : ParticleController
{
    [SerializeField] private ParticleSystem _fireExplosion;

    public void EnableFireExplosion()
    {
        _fireExplosion.Play();
    }
}
