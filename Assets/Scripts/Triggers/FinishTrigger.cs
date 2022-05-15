using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem _finishParticles;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _finishParticles.Play();
        }
    }
}
