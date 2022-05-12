using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fireExplosion;

    public void EnableFireExplosion()
    {
        _fireExplosion.Play();
    }
}
