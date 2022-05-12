using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _flashlight;
    [SerializeField] private ParticleSystem _iceExplosion;

    public void DisableFlashlight()
    {
        _flashlight.gameObject.SetActive(false);
    }

    public void EnableIceExplosion()
    {
        _iceExplosion.Play();
    }
}
