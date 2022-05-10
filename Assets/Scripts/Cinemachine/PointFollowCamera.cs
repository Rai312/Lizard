using UnityEngine;

public class PointFollowCamera : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
    }
}
