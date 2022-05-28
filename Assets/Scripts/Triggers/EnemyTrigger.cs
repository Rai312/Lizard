using UnityEngine;

[RequireComponent(typeof(HeadController))]
public class EnemyTrigger : MonoBehaviour
{
    private HeadController _headController;

    private void Start()
    {
        _headController = GetComponent<HeadController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _headController.EnableLookAt(enemy);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _headController.SwitchTarget();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _headController.DisableLookAt(enemy);
        }
    }
}
