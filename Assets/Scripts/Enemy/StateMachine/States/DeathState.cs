using UnityEngine;

public class DeathState : State
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _rigidbodies;

    private void OnEnable()
    {
        //MakePhysical();
    }

    private void MakePhysical()
    {
        _animator.enabled = false;

        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
        }
    }
}
