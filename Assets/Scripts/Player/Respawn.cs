using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EndOfMap>(out EndOfMap endOfLevel))
        {
            transform.position = _startPosition;
        }
    }
}
