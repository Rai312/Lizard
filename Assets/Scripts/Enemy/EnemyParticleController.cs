using UnityEngine;

public class EnemyParticleController : ParticleController
{
    [SerializeField] private ParticleSystem _flashlight;
    [SerializeField] private ParticleSystem _iceExplosion;
    [SerializeField] private ParticleSystem _poisonExplosion;

    public void DisableFlashlight()
    {
        _flashlight.gameObject.SetActive(false);
    }

    public void EnableIceExplosion()
    {
        _iceExplosion.Play();
    }

    public void EnablePoisonExplosion()
    {
        _poisonExplosion.Play();
    }
}
