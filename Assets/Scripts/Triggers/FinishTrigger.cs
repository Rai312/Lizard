using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem _finishParticles;
    [SerializeField] private DoorAnimationController _doorAnimationController;

    private float _durationWaitAfterFinishing = 2.5f;

    public event UnityAction Finished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(WaitingAfterFinishing());
        }
    }

    private IEnumerator WaitingAfterFinishing()
    {
        yield return new WaitForSeconds(_durationWaitAfterFinishing);

        _finishParticles.Play();
        Finished?.Invoke();
        _doorAnimationController.CloseDoor();
    }
}
