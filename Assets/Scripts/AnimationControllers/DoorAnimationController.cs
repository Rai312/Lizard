using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorAnimationController : MonoBehaviour
{
    private Animator _animator;

    private const string _isClose = "IsClose";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void CloseDoor()
    {
        _animator.SetBool(_isClose, true);
    }
}
