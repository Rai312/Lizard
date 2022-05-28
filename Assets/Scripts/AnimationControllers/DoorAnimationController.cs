using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorAnimationController : MonoBehaviour
{
    private const string _isClose = "IsClose";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void CloseDoor()
    {
        _animator.SetBool(_isClose, true);
    }
}
